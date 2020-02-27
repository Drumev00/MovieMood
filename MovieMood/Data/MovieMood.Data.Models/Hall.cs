namespace MovieMood.Data.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using MovieMood.Data.Common.Models;

    public class Hall : BaseDeletableModel<int>
    {
        public Hall()
        {
            this.Seats = new HashSet<Seat>();
            this.Projections = new HashSet<Projection>();
        }

        [Required]
        public string Name { get; set; }

        // Nav props:
        public virtual ICollection<Seat> Seats { get; set; }

        public virtual ICollection<Projection> Projections { get; set; }
    }
}
