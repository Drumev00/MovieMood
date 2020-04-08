namespace MovieMood.Web.ViewModels.Projections.Administration.InputModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using MovieMood.Data.Models;
    using MovieMood.Services.Mapping;
    using MovieMood.Web.ViewModels.Halls.Administration.ViewModels;

    public class EditProjectionViewModel : IMapFrom<Projection>
    {
        [Required]
        public string Id { get; set; }

        [Required]
        public DateTime Time { get; set; }

        public bool IsPremiere { get; set; }

        public bool Is3D { get; set; }

        [Required]
        public int HallId { get; set; }

        public IEnumerable<HallDropDownViewModel> Halls { get; set; }
    }
}
