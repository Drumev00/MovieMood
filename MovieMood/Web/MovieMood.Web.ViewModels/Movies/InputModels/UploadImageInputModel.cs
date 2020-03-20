namespace MovieMood.Web.ViewModels.Movies.InputModels
{
    using System.ComponentModel.DataAnnotations;

    public class UploadImageInputModel
    {
        [Required]
        public string ImagePath { get; set; }
    }
}
