namespace MovieMood.Data.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using MovieMood.Data.Common.Models;

    public class Ticket : BaseDeletableModel<string>
    {
        public Ticket()
        {
            this.TicketsOrders = new HashSet<TicketsOrders>();
        }

        [Required]
        public decimal Price { get; set; }

        // Nav props:
        public virtual int SeatId { get; set; }

        public virtual Seat Seat { get; set; }

        public virtual string ProjectionId { get; set; }

        public virtual Projection Projection { get; set; }

        public virtual ICollection<TicketsOrders> TicketsOrders { get; set; }
    }
}
