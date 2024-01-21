using System;

namespace Airport.Entities
{
    public class Inspection
    {
        public int Id { get; set; }

        public int PlaneId { get; set; }

        public Plane Plane { get; set; }

        public DateTime Date { get; set; }

        public string Result { get; set; }
    }
}