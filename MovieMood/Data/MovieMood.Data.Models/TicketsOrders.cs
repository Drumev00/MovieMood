namespace MovieMood.Data.Models
{
    public class TicketsOrders
    {
        public virtual string TicketId { get; set; }

        public virtual Ticket Ticket { get; set; }

        public virtual string OrderId { get; set; }

        public virtual Order Order { get; set; }
    }
}
