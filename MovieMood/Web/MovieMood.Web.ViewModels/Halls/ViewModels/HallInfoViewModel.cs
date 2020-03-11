namespace MovieMood.Web.ViewModels.Halls.ViewModels
{
    using System.Linq;

    using AutoMapper;
    using MovieMood.Data.Models;
    using MovieMood.Services.Mapping;

    public class HallInfoViewModel : IMapFrom<Hall>, IHaveCustomMappings
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string CreatedOn { get; set; }

        public int MaxSeats { get; set; }

        public int FreeSeats { get; set; }

        public void CreateMappings(IProfileExpression configuration)
        {
            configuration.CreateMap<Hall, HallInfoViewModel>().ForMember(
                h => h.FreeSeats,
                opt => opt.MapFrom(x => x.Seats.Count(s => !s.IsReserved)))
                .ForMember(
                h => h.MaxSeats,
                opt => opt.MapFrom(x => x.Seats.Count));
        }
    }
}
