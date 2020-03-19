namespace MovieMood.Services.Data.Movies
{
    using System.Threading.Tasks;

    using MovieMood.Web.ViewModels.Movies.InputModels;

    public interface IMoviesService
    {
        Task CreateAsync(CreateMovieInputModel model);
    }
}
