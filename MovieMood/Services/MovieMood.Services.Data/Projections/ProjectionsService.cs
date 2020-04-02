namespace MovieMood.Services.Data.Projections
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using MovieMood.Data.Common.Repositories;
    using MovieMood.Data.Models;
    using MovieMood.Services.Data.Movies;
    using MovieMood.Services.Mapping;
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

        public IEnumerable<T> All<T>()
        {
            var projections = this.projectionsRepository.AllAsNoTracking()
                .To<T>()
                .ToList();

            return projections;
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
