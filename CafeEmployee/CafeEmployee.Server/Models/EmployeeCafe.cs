namespace CafeEmployee.Server.Models
{
    public class EmployeeCafe
    {
        public Guid id { get; set; }
        public Guid employee_id { get; set; }
        public Guid cafe_id { get; set; }
        public DateTime start_date { get; set; }
        public DateTime? end_dete { get; set; }
        public bool is_active { get; set; }
    }
}
