namespace MovieMood.Web.ViewModels.Projections.Users.ViewModels
{
    using System.ComponentModel.DataAnnotations;

    using MovieMood.Data.Models;
    using MovieMood.Services.Mapping;

    public class ProjectionsTicketInfoViewModel : IMapFrom<Projection>
    {
        [Required]
        public string Id { get; set; }

        public bool IsPremiere { get; set; }

        public bool Is3D { get; set; }
    }
}
