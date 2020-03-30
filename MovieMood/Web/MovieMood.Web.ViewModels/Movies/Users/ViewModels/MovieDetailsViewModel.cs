namespace MovieMood.Web.ViewModels.Movies.Users.ViewModels
{
    using System;
    using System.Collections.Generic;

    using MovieMood.Data.Models;
    using MovieMood.Services.Mapping;

    public class MovieDetailsViewModel : IMapFrom<Movie>
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public string Resume { get; set; }

        public string ImagePath { get; set; }

        public TimeSpan Duration { get; set; }

        public string Cast { get; set; }

        public DateTime CreatedOn { get; set; }

        public string Director { get; set; }

        public string Trailer { get; set; }

        public IEnumerable<string> Genres { get; set; }
    }
}
