using System.Collections.Generic;

namespace Airport.Entities
{
    public class Department : BaseEntity
    {
        public List<Employee> Employees { get; set; } = new List<Employee>();

        public List<Administration> Administrations { get; set; } = new List<Administration>();
    }
}