using System;

namespace Airport.Entities
{
    public class MedicalExamination
    {
        public int Id { get; set; }

        public int EmployeeId { get; set; }

        public Employee Employee { get; set; }

        public DateTime Date { get; set; }

        public string Result { get; set; }
    }
}