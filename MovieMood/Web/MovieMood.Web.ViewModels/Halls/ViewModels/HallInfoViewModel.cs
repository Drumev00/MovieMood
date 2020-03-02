namespace MovieMood.Web.ViewModels.Halls.ViewModels
{
    public class HallInfoViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string CreatedOn { get; set; }

        public int MaxSeats { get; set; }

        public int FreeSeats { get; set; }
    }
}
