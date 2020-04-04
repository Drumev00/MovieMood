namespace MovieMood.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using MovieMood.Data.Common.Models;

    public class Order : BaseDeletableModel<string>
    {
        public Order()
        {
            this.Tickets = new HashSet<Ticket>();
        }

        [Required]
        public DateTime PurchaseDate { get; set; }

        [Required]
        public int TicketQuantity { get; set; }

        // Nav props:
        public string UserId { get; set; }

        public virtual ApplicationUser User { get; set; }

        public string ProjectionId { get; set; }

        public virtual Projection Projection { get; set; }

        public virtual ICollection<Ticket> Tickets { get; set; }
    }
}
