namespace MyRecipes.Web.ViewModels
{
    using System;
    using System.Collections.Generic;

    using MyRecipes.Web.ViewModels.Recipes;

    public class PagingViewModel
    {
        public IEnumerable<RecipeInListViewModel> Recipes { get; set; }

        public bool HasPreviousPage => this.PageNumber > 1;

        public bool HasNextPage => this.PageNumber < this.PagesCount;

        public int PagesCount => (int)Math.Ceiling((double)this.RecipesCount / this.ItemsPerPage);

        public int PageNumber { get; set; }

        public int PreviousPageNumber => this.PageNumber - 1;

        public int NextPageNumber => this.PageNumber + 1;

        public int FirstPage => 1;

        public int LastPage => this.PagesCount;

        public int RecipesCount { get; set; }

        public int ItemsPerPage { get; set; }
    }
}
