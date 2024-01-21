using System;
using System.Collections.Generic;

namespace Airport.Entities
{
    public class Passenger
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Passport { get; set; }

        public string Sex { get; set; }

        public DateTime Birthday { get; set; }

        public List<Ticket> Tickets { get; set; } = new List<Ticket>();
    }
}