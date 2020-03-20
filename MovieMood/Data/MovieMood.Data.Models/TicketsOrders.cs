namespace MovieMood.Data.Models
{
    using System;

    using MovieMood.Data.Common.Models;

    public class TicketsOrders : IAuditInfo, IDeletableEntity
    {
        public string TicketId { get; set; }

        public virtual Ticket Ticket { get; set; }

        public string OrderId { get; set; }

        public virtual Order Order { get; set; }

        public bool IsDeleted { get; set; }

        public DateTime? DeletedOn { get; set; }

        public DateTime CreatedOn { get; set; }

        public DateTime? ModifiedOn { get; set; }
    }
}
