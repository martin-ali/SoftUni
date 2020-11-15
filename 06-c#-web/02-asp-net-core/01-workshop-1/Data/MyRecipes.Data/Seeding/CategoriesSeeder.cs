namespace MyRecipes.Data.Seeding
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;

    using MyRecipes.Data.Models;

    public class CategoriesSeeder : ISeeder
    {
        public async Task SeedAsync(ApplicationDbContext dbContext, IServiceProvider serviceProvider)
        {
            if (dbContext.Categories.Any())
            {
                return;
            }

            await dbContext.Categories.AddAsync(new Category { Name = "Tart" });
            await dbContext.Categories.AddAsync(new Category { Name = "Cake" });
            await dbContext.Categories.AddAsync(new Category { Name = "Baked Pork" });

            await dbContext.SaveChangesAsync();
        }
    }
}
