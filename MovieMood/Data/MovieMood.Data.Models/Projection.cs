namespace MovieMood.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using MovieMood.Data.Common.Models;

    public class Projection : BaseDeletableModel<string>
    {
        public Projection()
        {
            this.Tickets = new HashSet<Ticket>();
            this.Orders = new HashSet<Order>();
        }

        [Required]
        public DateTime Time { get; set; }

        [Required]
        public bool IsPremiere { get; set; }

        [Required]
        public bool Is3D { get; set; }

        // Nav props:
        public int HallId { get; set; }

        public virtual Hall Hall { get; set; }

        public string MovieId { get; set; }

        public virtual Movie Movie { get; set; }

        public virtual ICollection<Ticket> Tickets { get; set; }

        public virtual ICollection<Order> Orders { get; set; }
    }
}
