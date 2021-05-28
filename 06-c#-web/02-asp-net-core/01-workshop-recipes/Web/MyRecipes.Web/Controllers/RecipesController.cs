namespace MyRecipes.Web.Controllers
{
    using System;
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;

    using MyRecipes.Data.Models;
    using MyRecipes.Services.Data;
    using MyRecipes.Web.ViewModels;
    using MyRecipes.Web.ViewModels.Recipes;

    public class RecipesController : BaseController
    {
        private readonly ICategoriesService categoriesService;
        private readonly IRecipesService recipesService;
        private readonly UserManager<ApplicationUser> userManager;
        private readonly IWebHostEnvironment environment;

        public RecipesController(
            ICategoriesService categoriesService,
            IRecipesService recipesService,
            UserManager<ApplicationUser> userManager,
            IWebHostEnvironment webHostEnvironment)
        {
            this.categoriesService = categoriesService;
            this.recipesService = recipesService;
            this.userManager = userManager;
            this.environment = webHostEnvironment;
        }

        [HttpGet]
        public IActionResult All(int id = 1)
        {
            var firstPage = 1;
            var pageNumberIsValid = firstPage <= id && id <= this.recipesService.GetCount();
            if (pageNumberIsValid == false)
            {
                return this.NotFound();
            }

            const int itemsPerPage = 12;
            var viewModel = new PagingViewModel
            {
                ItemsPerPage = itemsPerPage,
                PageNumber = id,
                RecipesCount = this.recipesService.GetCount(),
                Recipes = this.recipesService.GetAll<RecipeInListViewModel>(id, itemsPerPage),
            };

            // return this.View();
            return this.View(viewModel);
        }

        [Authorize]
        [HttpGet]
        public IActionResult Create()
        {
            var viewModel = new CreateRecipeInputModel();
            viewModel.CategoriesItems = this.categoriesService.GetAllKeysAsKeyValuePairs();

            return this.View(viewModel);
        }

        [HttpPost]
        // [AllowedExtensions]
        public async Task<IActionResult> Create(CreateRecipeInputModel input)
        {
            if (this.ModelState.IsValid == false)
            {
                input.CategoriesItems = this.categoriesService.GetAllKeysAsKeyValuePairs();
                return this.View(input);
            }

            var user = await this.userManager.GetUserAsync(this.User);

            try
            {
                await this.recipesService.CreateAsync(input, user.Id, $"{this.environment.WebRootPath}/images");
            }
            catch (Exception exception)
            {
                this.ModelState.AddModelError(string.Empty, exception.Message);
                input.CategoriesItems = this.categoriesService.GetAllKeysAsKeyValuePairs();

                return this.View(input);
            }

            return this.RedirectToAction(nameof(RecipesController.All), nameof(RecipesController));
        }

        [HttpGet]
        public IActionResult Details()
        {
            return this.View();
        }
    }
}
