namespace MovieMood.Web.ViewModels.Halls.Administration.InputModels
{
    using System.ComponentModel.DataAnnotations;

    public class CreateHallInputModel
    {
        [Required]
        [MaxLength(20)]
        public string Name { get; set; }
    }
}
