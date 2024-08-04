using Swashbuckle.AspNetCore.Annotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace CafeEmployee.Server.Models
{
    public class Employee
    {

        [SwaggerSchema(ReadOnly = true)]
        public Guid id { get; set; }
        public string name { get; set; } = string.Empty;
        public string email_address { get; set; } = string.Empty;
        public string phone_number { get; set; } = string.Empty;
        public string gender { get; set; } = string.Empty;
        [SwaggerSchema(ReadOnly = true)]
        [NotMapped]
        public int days_worked { get; set; }
        public string cafe { get; set; } = string.Empty;
        [SwaggerSchema(ReadOnly = true)]
        [NotMapped]
        public DateTime start_date { get; set; }
    }
}
