namespace MovieMood.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using MovieMood.Data.Common.Models;

    public class Movie : BaseDeletableModel<string>
    {
        public Movie()
        {
            this.Projections = new HashSet<Projection>();
            this.MovieGenres = new HashSet<MovieGenres>();
        }

        [Required]
        [MaxLength(80)]
        public string Name { get; set; }

        [Required]
        [MaxLength(500)]
        public string Resume { get; set; }

        [Required]
        public string ImagePath { get; set; }

        [Required]
        public TimeSpan Duration { get; set; }

        [Required]
        [MaxLength(150)]
        public string Cast { get; set; }

        [Required]
        [MaxLength(40)]
        public string Director { get; set; }

        public string Trailer { get; set; }

        // Nav props:
        public virtual ICollection<Projection> Projections { get; set; }

        public virtual ICollection<MovieGenres> MovieGenres { get; set; }
    }
}
