using System.Collections.Generic;

namespace Airport.Entities
{
    public class Route
    {
        public int Id { get; set; }

        public string Source { get; set; }

        public string TransferPoint { get; set; }

        public string Destination { get; set; }

        public List<Flight> Flights { get; set; } = new List<Flight>();
    }
}