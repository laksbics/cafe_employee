using Swashbuckle.AspNetCore.Annotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace CafeEmployee.Server.Models
{
    public class Cafe
    {

        [SwaggerSchema(ReadOnly = true)]
        public Guid id { get; set; }
        public string name { get; set; } = string.Empty;
        public string description { get; set; } = string.Empty;
        public byte[] logo { get; set; } = [];
        public string location { get; set; } = string.Empty;
        [SwaggerSchema(ReadOnly = true)]
        [NotMapped]
        public int noOfemployees { get; set; }
    }
}
