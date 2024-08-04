using CafeEmployee.Server.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata.Ecma335;

namespace CafeEmployee.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EmployeesController : ControllerBase
    {
        private readonly EmployeeContext _dbContext;
        private readonly ILogger<EmployeesController> _logger;

        public EmployeesController(ILogger<EmployeesController> logger, EmployeeContext dbContext)
        {
            _logger = logger;
            _dbContext = dbContext;
        }

        // GET: /Employees
        [HttpGet]
        [ActionName(nameof(GetEmployees))]
        public async Task<ActionResult<IEnumerable<Employee>>> GetEmployees()
        {
            try
            {
                if (_dbContext.Employees == null)
                {
                    return NotFound();
                }

                var employeeList = (from emp in _dbContext.Employees
                                    select new Employee
                                    {
                                        id = emp.id,
                                        name = emp.name,
                                        email_address = emp.email_address,
                                        phone_number = emp.phone_number,
                                        gender = emp.gender,
                                        days_worked = 0,
                                        start_date = ((from e in _dbContext.EmployeeCafe
                                                       where emp.id == e.employee_id
                                                       select e.start_date).FirstOrDefault()),
                                        cafe = ((from e in _dbContext.EmployeeCafe
                                                 where emp.id == e.employee_id
                                                 join c in _dbContext.Cafes on e.cafe_id equals c.id
                                                 select c.name).FirstOrDefault()) ?? string.Empty
                                    }).ToList();

                foreach (var emp in employeeList)
                {
                    emp.days_worked = (DateTime.Now - emp.start_date).Days;
                }

                return employeeList.OrderByDescending(c => c.days_worked).ToList();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                return new JsonResult(new { status = "error", message = "error in Getting Employees" });
            }

        }

        [HttpPost]
        [ActionName(nameof(PostEmployee))]
        public async Task<ActionResult<Employee>> PostEmployee(Employee employee)
        {
            try
            {
                employee.id = Guid.NewGuid();
                _dbContext.Employees.Add(employee);

                if (string.IsNullOrEmpty(employee.cafe) == false)
                {
                    var cafe = _dbContext.Cafes.Where(e => e.name == employee.cafe).FirstOrDefault();

                    if ((cafe != null))
                    {
                        _dbContext.EmployeeCafe.Add(new EmployeeCafe
                        {
                            id = Guid.NewGuid(),
                            employee_id = employee.id,
                            cafe_id = cafe.id,
                            start_date = DateTime.Now,
                            is_active = true
                        });
                    }
                }

                await _dbContext.SaveChangesAsync();

                return CreatedAtAction(nameof(PostEmployee), new { id = employee.id }, employee);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                return new JsonResult(new { status = "error", message = "error in Saving Employee" });

            }
        }

        // GET: /Employees/cafeName
        [HttpGet("{cafe}")]
        [ActionName(nameof(GetEmployee))]
        public async Task<ActionResult<IEnumerable<Employee>>> GetEmployee(Guid cafe)
        {
            try
            {
                if (_dbContext.Employees == null)
                {
                    return NotFound();
                }

                if (cafe == null || cafe == Guid.Empty)
                {
                    var employeeList = (from emp in _dbContext.Employees
                                        select new Employee
                                        {
                                            id = emp.id,
                                            name = emp.name,
                                            email_address = emp.email_address,
                                            phone_number = emp.phone_number,
                                            gender = emp.gender,
                                            days_worked = 0,
                                            start_date = ((from e in _dbContext.EmployeeCafe
                                                           where emp.id == e.employee_id
                                                           select e.start_date).FirstOrDefault()),
                                            cafe = ((from e in _dbContext.EmployeeCafe
                                                     where emp.id == e.employee_id
                                                     join c in _dbContext.Cafes on e.cafe_id equals c.id
                                                     select c.name).FirstOrDefault()) ?? string.Empty
                                        }).ToList();

                    foreach (var emp in employeeList)
                    {
                        emp.days_worked = (DateTime.Now - emp.start_date).Days;
                    }

                    return employeeList.OrderByDescending(c => c.days_worked).ToList();
                }
                else
                {
                    var employeeList =
                        (from emp in _dbContext.Employees
                         join empCaf in _dbContext.EmployeeCafe.Where(c => c.cafe_id == cafe) on emp.id equals empCaf.employee_id
                         select new Employee
                         {
                             id = emp.id,
                             name = emp.name,
                             email_address = emp.email_address,
                             phone_number = emp.phone_number,
                             gender = emp.gender,
                             days_worked = 0,
                             start_date = ((from e in _dbContext.EmployeeCafe
                                            where emp.id == e.employee_id
                                            select e.start_date).FirstOrDefault()),
                             cafe = ((from e in _dbContext.EmployeeCafe
                                      where emp.id == e.employee_id
                                      join c in _dbContext.Cafes on e.cafe_id equals c.id
                                      select c.name).FirstOrDefault()) ?? string.Empty
                         }).ToList();

                    foreach (var emp in employeeList)
                    {
                        emp.days_worked = (DateTime.Now - emp.start_date).Days;
                    }

                    return employeeList.OrderByDescending(c => c.days_worked).ToList();
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                return new JsonResult(new { status = "error", message = "error in Getting Employee" });

            }
        }

        // PUT: Employees/5
        [HttpPut("{id}")]
        [ActionName(nameof(PutEmployee))]
        public async Task<IActionResult> PutEmployee(Guid id, Employee employee)
        {
            try
            {
                employee.id = id;
                _dbContext.Entry(employee).State = EntityState.Modified;

                var employeeCafe = _dbContext.EmployeeCafe.Where(e => e.employee_id == id).FirstOrDefault();

                if (employeeCafe != null)
                {
                    _dbContext.EmployeeCafe.Remove(employeeCafe);
                }

                if (string.IsNullOrEmpty(employee.cafe) == false)
                {
                    var cafe = _dbContext.Cafes.Where(e => e.name == employee.cafe).FirstOrDefault();

                    if ((cafe != null))
                    {
                        _dbContext.EmployeeCafe.Add(new EmployeeCafe
                        {
                            id = Guid.NewGuid(),
                            employee_id = employee.id,
                            cafe_id = cafe.id,
                            start_date = DateTime.Now,
                            is_active = true
                        });
                    }
                }

                await _dbContext.SaveChangesAsync();
                return CreatedAtAction(nameof(PutEmployee), new { id = employee.id }, employee);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                return new JsonResult(new { status = "error", message = "error in updatting Employee" });

            }
        }

        // DELETE: Employees/5
        [HttpDelete("{id}")]
        [ActionName(nameof(DeleteEmployee))]
        public async Task<IActionResult> DeleteEmployee(Guid id)
        {
            try
            {
                if (_dbContext.Employees == null)
                {
                    return NotFound();
                }

                var employee = await _dbContext.Employees.FindAsync(id);
                if (employee == null)
                {
                    return NotFound();
                }

                _dbContext.Employees.Remove(employee);
                await _dbContext.SaveChangesAsync();
                return new JsonResult(new { status = "Success", message = "Employee details are deleted successfully." });

            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                return new JsonResult(new { status = "error", message = "error in Deleting Employee" });
            }
        }

        private bool EmployeeExists(Guid id)
        {
            return (_dbContext.Employees?.Any(e => e.id == id)).GetValueOrDefault();
        }
    }
}
