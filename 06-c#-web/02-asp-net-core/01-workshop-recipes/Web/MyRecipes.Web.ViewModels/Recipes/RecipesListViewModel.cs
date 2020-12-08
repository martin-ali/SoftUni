using System.Collections.Generic;

namespace MyRecipes.Web.ViewModels.Recipes
{
    public class RecipesListViewModel
    {
        public IEnumerable<RecipeInListViewModel> Recipes { get; set; }

        public int PageNumber { get; set; }
    }
}
