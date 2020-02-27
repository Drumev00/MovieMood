namespace MovieMood.Data.Models.Enums
{
    using System.ComponentModel.DataAnnotations;

    public enum Genre
    {
        Action = 0,
        Adventure = 1,
        Comedy = 2,
        Crime = 3,
        Drama = 4,
        Fantasy = 5,
        Historical = 6,
        Horror = 7,
        Mystery = 8,
        Romantic = 9,
        [Display(Name = "Sci-fi")]
        ScienceFiction = 10,
        Thriller = 11,
        Western = 12,
        Animation = 13,
    }
}
