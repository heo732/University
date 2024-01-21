using System;
using System.Collections.Generic;

namespace Airport.Entities
{
    public class Employee
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public DateTime Birthday { get; set; }

        public string Sex { get; set; }

        public int ChildrenNumber { get; set; }

        public DateTime HiredDate { get; set; }

        public double Salary { get; set; }

        public int DepartmentId { get; set; }

        public Department Department { get; set; }

        public int BrigadeId { get; set; }

        public Team Team { get; set; }

        public List<Administration> Administrations { get; set; } = new List<Administration>();

        public List<MedicalExamination> MedicalExaminations { get; set; } = new List<MedicalExamination>();
    }
}