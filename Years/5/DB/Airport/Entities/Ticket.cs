namespace Airport.Entities
{
    public class Ticket
    {
        public int Id { get; set;}

        public int FlightId { get; set; }

        public Flight Flight { get; set; }

        public int PassengerId { get; set; }

        public Passenger Passenger { get; set; }

        public int TicketStateId { get; set; }

        public TicketState TicketState { get; set; }

        public bool Luggage { get; set; }
    }
}