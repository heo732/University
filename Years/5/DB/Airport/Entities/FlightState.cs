using System.Collections.Generic;

namespace Airport.Entities
{
    public class FlightState : BaseEntity
    {
        public List<Flight> Flights { get; set; } = new List<Flight>();
    }
}