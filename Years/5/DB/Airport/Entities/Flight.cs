using System;
using System.Collections.Generic;

namespace Airport.Entities
{
    public class Flight
    {
        public int Id { get; set; }

        public int PlaneId { get; set; }

        public Plane Plane { get; set; }

        public int FlightStateId { get; set; }

        public FlightState FlightState { get; set; }

        public int FlightTypeId { get; set; }

        public FlightType FlightType { get; set; }

        public int RouteId { get; set; }

        public Route Route { get; set; }

        public DateTime Departure { get; set; }

        public DateTime Arrival { get; set; }

        public double TicketPrice { get; set; }

        public List<Ticket> Tickets { get; set; } = new List<Ticket>();
    }
}