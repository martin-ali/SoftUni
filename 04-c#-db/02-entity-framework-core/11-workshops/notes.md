# Workshop 1

## Information

- Controller
    - Name -> [Resource]+Controller
    - Inherits Controller
- ConfigureServices(IServiceCollection services)
    - services.AddDbContext<PetDbContext>()
    - services.AddTransient<IPetService, PetService>()
        - Dependency injection
        - Through constructor
    - services.AddControllerWithViews()
    - Views
        - Pets
            - All.cshtml
