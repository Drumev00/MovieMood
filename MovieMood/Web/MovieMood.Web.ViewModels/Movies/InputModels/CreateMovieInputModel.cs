
namespace MovieMood.Web.ViewModels.Movies.InputModels
{
    using System;
    using System.ComponentModel.DataAnnotations;

    using MovieMood.Data.Models.Enums;

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
    }
}
