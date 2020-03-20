namespace MovieMood.Services.Data.MovieGenres
{
    using System.Threading.Tasks;

    public interface IMovieGenresService
    {
        Task CreateMappingAsync(string movieId, string genre);
    }
}
