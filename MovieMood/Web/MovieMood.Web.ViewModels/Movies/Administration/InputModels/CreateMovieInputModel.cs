namespace MovieMood.Web.ViewModels.Movies.Administration.InputModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class CreateMovieInputModel
    {
        [Required]
        [MaxLength(80)]
        public string Name { get; set; }

        [Required]
        public string ImagePath { get; set; }

        [Required]
        [MaxLength(500)]
        public string Resume { get; set; }

        [Required]
        public TimeSpan Duration { get; set; }

        [Required]
        [MaxLength(150)]
        public string Cast { get; set; }

        [Required]
        [MaxLength(40)]
        public string Director { get; set; }

        public string Trailer { get; set; }

        public ICollection<string> AreChecked { get; set; }
    }
}
