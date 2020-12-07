namespace MyRecipes.Web.Controllers
{
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Mvc;

    using MyRecipes.Services.Data;
    using MyRecipes.Web.ViewModels.Recipes;

    public class RecipesController : BaseController
    {
        private readonly ICategoriesService categoriesService;
        private readonly IRecipesService recipesService;

        public RecipesController(ICategoriesService categoriesService, IRecipesService recipesService)
        {
            this.categoriesService = categoriesService;
            this.recipesService = recipesService;
        }

        [HttpGet("/Recipes")]
        public IActionResult Create()
        {
            var viewModel = new CreateRecipeInputModel();
            viewModel.CategoriesItems = this.categoriesService.GetAllKeysAsKeyValuePairs();

            return this.View(viewModel);
        }

        [HttpPost("/Recipes")]
        public async Task<IActionResult> Create(CreateRecipeInputModel input)
        {
            if (this.ModelState.IsValid == false)
            {
                input.CategoriesItems = this.categoriesService.GetAllKeysAsKeyValuePairs();
                return this.View(input);
            }

            await this.recipesService.CreateAsync(input);

            return this.Redirect("/Recipes");
        }
    }
}
