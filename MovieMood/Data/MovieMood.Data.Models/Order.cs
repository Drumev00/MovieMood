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
            this.TicketsOrders = new HashSet<TicketsOrders>();
        }

        [Required]
        public DateTime PurchaseDate { get; set; }

        [Required]
        public int TicketQuantity { get; set; }

        // Nav props:
        public string UserId { get; set; }

        public virtual ApplicationUser User { get; set; }

        public virtual ICollection<TicketsOrders> TicketsOrders { get; set; }
    }
}
