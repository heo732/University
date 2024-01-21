using System.Collections.Generic;

namespace Airport.Entities
{
    public class TicketState : BaseEntity
    {
        public List<Ticket> Tickets { get; set; } = new List<Ticket>();
    }
}