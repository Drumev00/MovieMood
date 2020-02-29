namespace MovieMood.Web.ViewModels.Halls.InputModels
{
    using System.ComponentModel.DataAnnotations;

    public class CreateHallInputModel
    {
        [Required]
        [MaxLength(20)]
        public string Name { get; set; }
    }
}
