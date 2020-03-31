namespace MovieMood.Services.Data.Projections
{
    using System;
    using System.Threading.Tasks;

    using MovieMood.Data.Common.Repositories;
    using MovieMood.Data.Models;
    using MovieMood.Services.Data.Movies;
    using MovieMood.Web.ViewModels.Projections.Administration.InputModels;

    public class ProjectionsService : IProjectionsService
    {
        private readonly IDeletableEntityRepository<Projection> projectionsRepository;
        private readonly IMoviesService moviesService;

        public ProjectionsService(
            IDeletableEntityRepository<Projection> projectionsRepository,
            IMoviesService moviesService)
        {
            this.projectionsRepository = projectionsRepository;
            this.moviesService = moviesService;
        }

        public async Task CreateAsync(CreateProjectionInputModel model)
        {
            var movieId = this.moviesService.GetIdByName(model.MovieName);

            var projection = new Projection
            {
                Id = Guid.NewGuid().ToString(),
                Time = model.Time,
                IsPremiere = model.IsPremiere,
                Is3D = model.Is3D,
                HallId = model.HallId,
                MovieId = movieId,
            };

            await this.projectionsRepository.AddAsync(projection);
            await this.projectionsRepository.SaveChangesAsync();
        }
    }
}
