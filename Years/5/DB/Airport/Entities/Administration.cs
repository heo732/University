using System.ComponentModel.DataAnnotations;

namespace Airport.Entities
{
    public class Administration
    {
        [Key]
        public int DepartmentId { get; set; }

        public Department Department { get; set; }

        public int EmployeeId { get; set; }

        public Employee Employee { get; set; }
    }
}