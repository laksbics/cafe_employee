using CafeEmployee.Server.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CafeEmployee.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CafesController : ControllerBase
    {
        private readonly EmployeeContext _dbContext;
        private readonly ILogger<CafesController> _logger;

        public CafesController(ILogger<CafesController> logger, EmployeeContext dbContext)
        {
            _logger = logger;
            _dbContext = dbContext;
        }

        // GET: /Cafes
        [HttpGet]
        [ActionName(nameof(GetCafes))]
        public async Task<ActionResult<IEnumerable<Cafe>>> GetCafes()
        {
            try
            {
                if (_dbContext.Cafes == null)
                {
                    return NotFound();
                }

                return await (from cafe in _dbContext.Cafes
                              select new Cafe
                              {
                                  id = cafe.id,
                                  name = cafe.name,
                                  logo = cafe.logo,
                                  description = cafe.description,
                                  location = cafe.location,
                                  noOfemployees = ((from e in _dbContext.EmployeeCafe
                                                    where cafe.id == e.cafe_id
                                                    select e).Count())
                              }).OrderByDescending(c => c.noOfemployees).ToListAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                return new JsonResult(new { status = "error", message = "error in Getting Cafe" });
            }
        }

        [HttpPost]
        //[HttpPost("upload")]
        [ActionName(nameof(PostCafe))]
        public async Task<ActionResult<Cafe>> PostCafe([FromBody] Cafe cafe)
        {
            try
            {
                if (cafe == null || cafe.logo == null || cafe.logo.Length == 0)
                {
                    return BadRequest("Invalid file upload request.");
                }

                cafe.id = Guid.NewGuid();
                _dbContext.Cafes.Add(cafe);
                await _dbContext.SaveChangesAsync();

                return CreatedAtAction(nameof(PostCafe), new { id = cafe.id }, cafe);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                return new JsonResult(new { status = "error", message = "error in Saving Cafe" });
            }
        }

        // GET: /Cafe/locationName
        [HttpGet("{location}")]
        [ActionName(nameof(GetCafe))]
        public async Task<ActionResult<IEnumerable<Cafe>>> GetCafe(string location)
        {
            try
            {
                if (_dbContext.Cafes == null)
                {
                    return NotFound();
                }

                if (string.IsNullOrEmpty(location))
                {
                    return await (from cafe in _dbContext.Cafes
                                  select new Cafe
                                  {
                                      id = cafe.id,
                                      name = cafe.name,
                                      logo = cafe.logo,
                                      description = cafe.description,
                                      location = cafe.location,
                                      noOfemployees = ((from e in _dbContext.EmployeeCafe
                                                        where cafe.id == e.cafe_id
                                                        select e).Count())
                                  }).OrderByDescending(c => c.noOfemployees).ToListAsync();

                }
                else
                {
                    return await (from cafe in _dbContext.Cafes
                                  select new Cafe
                                  {
                                      id = cafe.id,
                                      name = cafe.name,
                                      logo = cafe.logo,
                                      description = cafe.description,
                                      location = cafe.location,
                                      noOfemployees = ((from e in _dbContext.EmployeeCafe
                                                        where cafe.id == e.cafe_id
                                                        select e).Count())
                                  }).Where(c => c.location == location).OrderByDescending(c => c.noOfemployees).ToListAsync();
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                return new JsonResult(new { status = "error", message = "error in Getting Cafe" });
            }
        }

        // PUT: Cafe/5
        [HttpPut("{id}")]
        [ActionName(nameof(PutCafe))]
        public async Task<IActionResult> PutCafe(Guid id, [FromBody]  Cafe cafe)
        {
            cafe.id = id;
            _dbContext.Entry(cafe);
          
            try
            {
                await _dbContext.SaveChangesAsync();
                return CreatedAtAction(nameof(PutCafe), new { id = cafe.id }, cafe);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                return new JsonResult(new { status = "error", message = "error in updating Cafe" });
            }
        }

        // DELETE: Cafe/5
        [HttpDelete("{id}")]
        [ActionName(nameof(DeleteCafe))]
        public async Task<IActionResult> DeleteCafe(Guid id)
        {
            try
            { 
                if (_dbContext.Cafes == null)
                {
                    return NotFound();
                }

                var cafe = await _dbContext.Cafes.FindAsync(id);
                if (cafe == null)
                {
                    return NotFound();
                }

                _dbContext.Cafes.Remove(cafe);
                await _dbContext.SaveChangesAsync();
                return new JsonResult(new { status = "success", message = "Deleted the Cafe" });

            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                return new JsonResult(new { status = "error", message = "error in Getting Cafe" });
            }
        }

        private bool CafeExists(Guid id)
        {
            return (_dbContext.Cafes?.Any(e => e.id == id)).GetValueOrDefault();
        }
    }
}

