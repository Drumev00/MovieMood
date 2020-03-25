namespace MovieMood.Services.Data.MovieGenres
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IMovieGenresService
    {
        Task CreateMappingAsync(string movieId, string genre);

        IEnumerable<string> GetGenres(string movieId);
    }
}
