namespace MovieMood.Web.Controllers
{
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using MovieMood.Common;
    using MovieMood.Services.Data.Halls;
    using MovieMood.Web.ViewModels.Halls.InputModels;
    using MovieMood.Web.ViewModels.Halls.ViewModels;

    [Authorize(Roles = GlobalConstants.AdministratorRoleName)]
    public class HallsController : BaseController
    {
        private readonly IHallsService hallsService;

        public HallsController(IHallsService hallsService)
        {
            this.hallsService = hallsService;
        }

        public IActionResult Create()
        {
            return this.View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateHallInputModel input)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(input);
            }

            await this.hallsService.CreateAsync(input.Name);

            return this.Redirect("/Home/Index");
        }

        [HttpGet("/Halls")]
        public IActionResult Choose()
        {
            return this.View();
        }

        public IActionResult All()
        {
            var hallList = new HallListingViewModel
            {
                Halls = this.hallsService.All<HallInfoViewModel>(),
            };

            return this.View(hallList);
        }

        public IActionResult Details(int hallId)
        {
            var viewModel = this.hallsService.GetDetailsById<HallDetailsViewModel>(hallId);

            return this.View(viewModel);
        }

        public async Task<IActionResult> Delete(int hallId)
        {
           await this.hallsService.SoftDeleteHallAsync(hallId);

           return this.Redirect("/Halls/All");
        }
    }
}
