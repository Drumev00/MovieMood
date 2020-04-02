namespace MovieMood.Web.ViewModels.Projections.Users.ViewModels
{
    using System;

    using MovieMood.Data.Models;
    using MovieMood.Services.Mapping;

    public class ProjectionsInfoViewModel : IMapFrom<Projection>
    {
        public string Id { get; set; }

        public DateTime Time { get; set; }

        public bool IsPremiere { get; set; }

        public bool Is3D { get; set; }

        public string MovieName { get; set; }

        public string MovieImagePath { get; set; }
    }
}
