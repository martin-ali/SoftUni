namespace MyRecipes.Services.Data
{
    using MyRecipes.Services.Data.Models;

    public interface IGetCountsService
    {
        // Options
        // 1 - Use a ViewModel
        // 2 - Use a DTO
        // 3 - Use a Tuple
        CountsDto GetCounts();
    }
}
