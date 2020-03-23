namespace MovieMood.Web.ViewModels.Movies.Users.ViewModels
{
    using AutoMapper;
    using MovieMood.Data.Models;
    using MovieMood.Services.Mapping;

    public class MovieInfoViewModel : IMapFrom<Movie>, IHaveCustomMappings
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public string ImagePath { get; set; }

        public string ShortResume { get; set; }

        public string Director { get; set; }

        public void CreateMappings(IProfileExpression configuration)
        {
            configuration.CreateMap<Movie, MovieInfoViewModel>().ForMember(
                m => m.ShortResume,
                opt => opt.MapFrom(x => x.Resume.Substring(0, 90) + "..."));
        }
    }
}
