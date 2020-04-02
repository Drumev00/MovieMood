namespace MovieMood.Web.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using MovieMood.Services.Data.Projections;
    using MovieMood.Web.ViewModels.Projections.Users.ViewModels;

    public class ProjectionsController : BaseController
    {
        private readonly IProjectionsService projectionsService;

        public ProjectionsController(IProjectionsService projectionsService)
        {
            this.projectionsService = projectionsService;
        }

        public IActionResult All()
        {
            var viewModel = new ProjectionsListingViewModel()
            {
                Projections = this.projectionsService.All<ProjectionsInfoViewModel>(),
            };

            return this.View(viewModel);
        }
    }
}
