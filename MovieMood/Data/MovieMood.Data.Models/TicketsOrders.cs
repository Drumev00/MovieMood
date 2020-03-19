namespace MovieMood.Data.Models
{
    public class TicketsOrders
    {
        public string TicketId { get; set; }

        public virtual Ticket Ticket { get; set; }

        public string OrderId { get; set; }

        public virtual Order Order { get; set; }
    }
}
