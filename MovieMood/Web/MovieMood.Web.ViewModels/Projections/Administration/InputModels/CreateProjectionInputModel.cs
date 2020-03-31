namespace MovieMood.Web.ViewModels.Projections.Administration.InputModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using MovieMood.Web.ViewModels.Halls.Administration.ViewModels;

    public class CreateProjectionInputModel
    {
        [Required]
        public DateTime Time { get; set; }

        [Required]
        public bool IsPremiere { get; set; }

        [Required]
        public bool Is3D { get; set; }

        public int HallId { get; set; }

        public IEnumerable<HallDropDownViewModel> Halls { get; set; }

        public string MovieName { get; set; }
    }
}