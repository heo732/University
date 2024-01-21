using System.Collections.Generic;

namespace Airport.Entities
{
    public class FlightType : BaseEntity
    {
        public List<Flight> Flights { get; set; } = new List<Flight>();
    }
}