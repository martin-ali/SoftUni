﻿namespace MyRecipes.Web.Controllers
{
    using System.Diagnostics;

    using Microsoft.AspNetCore.Mvc;

    using MyRecipes.Services.Data;
    using MyRecipes.Web.ViewModels;
    using MyRecipes.Web.ViewModels.Home;

    public class HomeController : BaseController
    {
        private readonly IGetCountsService countsService;

        public HomeController(IGetCountsService countsService)
        {
            this.countsService = countsService;
        }

        public IActionResult Index()
        {
            var counts = this.countsService.GetCounts();
            var viewModel = new IndexViewModel
            {
                CategoriesCount = counts.CategoriesCount,
                ImagesCount = counts.ImagesCount,
                IngredientsCount = counts.IngredientsCount,
                RecipesCount = counts.RecipesCount,
            };

            return this.View(viewModel);
        }

        public IActionResult Privacy()
        {
            return this.View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return this.View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? this.HttpContext.TraceIdentifier });
        }
    }
}
