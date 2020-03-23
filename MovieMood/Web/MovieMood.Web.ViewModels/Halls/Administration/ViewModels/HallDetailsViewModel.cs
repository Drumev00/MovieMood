namespace MovieMood.Web.ViewModels.Halls.Administration.ViewModels
{
    using MovieMood.Data.Models;
    using MovieMood.Services.Mapping;

    public class HallDetailsViewModel : IMapFrom<Hall>
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string CreatedOn { get; set; }
    }
}
