namespace MovieMood.Web.Areas.Administration.Controllers
{
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Mvc;
    using MovieMood.Services.Data.Halls;
    using MovieMood.Services.Data.Projections;
    using MovieMood.Web.ViewModels.Halls.Administration.ViewModels;
    using MovieMood.Web.ViewModels.Projections.Administration.InputModels;

    public class ProjectionsController : AdministrationController
    {
        private readonly IProjectionsService projectionsService;
        private readonly IHallsService hallsService;

        public ProjectionsController(
            IProjectionsService projectionsService,
            IHallsService hallsService)
        {
            this.projectionsService = projectionsService;
            this.hallsService = hallsService;
        }

        public IActionResult Create()
        {
            var halls = this.hallsService.All<HallDropDownViewModel>();
            var viewModel = new CreateProjectionInputModel
            {
                Halls = halls,
            };

            return this.View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateProjectionInputModel model)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(model);
            }

            await this.projectionsService.CreateAsync(model);

            return this.Redirect("/Projections/All");
        }

        public IActionResult Edit(string projectionId)
        {
            var viewModel = this.projectionsService.GetById<EditProjectionViewModel>(projectionId);
            viewModel.Halls = this.hallsService.All<HallDropDownViewModel>();
            this.TempData["projectionId"] = projectionId;

            return this.View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(EditProjectionViewModel model)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(model);
            }

            await this.projectionsService.EditAsync(model);

            return this.Redirect("/Projections/All");
        }

        public async Task<IActionResult> Delete(string projectionId)
        {
            await this.projectionsService.DeleteAsync(projectionId);

            return this.Redirect("/Projections/All");
        }
    }
}
