# ASP.NET Core

## Introduction

- APS (Active Server Pages)
- Compared to ASP.NET MVC
    - Much less coupled to libraries
    - Not as monolithic
    - Uses NuGet for all components
    - Much faster
    - Not as tied to monolithic components
        - Modular
    - Uses JSON instead of XML by default
- View components
- Convention over configuration
- Model binding
- Model validation
    - Client-side
    - Server-side
- Middleware

### Service Types

- Scoped
    - New instance every request
- Transient
    - New instance every single time it's needed
- Static

### Razor

- View engine
- Avoid ViewBag and ViewData

### Controller

- Inherits Controller class
- Action
- Not static
- Can return *anything*
- Routing
    - Conventional
        - Recommended
    - Attribute routing
        - Not recommended
        - Makes tracing valid routes difficult
        - Harder debugging
    - The "/" symbol overrides the controller route
    - Constraint
        - Using ":"

#### Attributes

- [FromHeader]
- [NonAction]
- [ActionName]

### Validation

- ModelState.IsValid()

### Identity

- Authentication
- Authorization

## Project Defense

- Not necessary to be responsive
- Ideas:
    - Learning system
    - Social network
    - Spotify
    - Online store
- Facebook course group for examples
- Hosted online or locally is fine
- Niki's template
- Used during hiring
- RequireConfirmedAccount
- In ASP.NET MVC projects, the connection string defaults to localdb
- SQL injection
- Script injection
- Cross-site scripting
- Sanitizer
- Users can differ in roles and data? Link to other table with the additional data
- Hangfire
- Must be hosted

## Razor Views

### Misc

- Partial views
- HTML Helpers
- Client gets only HTML
    - All logic is handled server-side
- Views have access to loads of stuff
- HSTS
- [DataType(DataType.MultilineText)]
- HTML helpers
    - Superseded by tag helpers
- Tag helpers
    - asp-for

### Special Files

- _Layout
    - @RenderBody()
    - this.Layout
- _ViewStart
- _ViewImports
- _ViewStart

### Keywords

- @using
- @model
- @inject
- @addTagHelper
    - Can add custom tag helpers
- @section

### Transfer to view

- ViewBag
    - Dynamic
    - Global
- ViewData
    - Dictionary
    - Global
- ViewModel
    - Better due to
        - Obvious description of data
        - Intellisense
        - Compilation errors
- ViewBag and ViewData are connected and share data

### HTML Helpers

- Tag helpers supersede these
- this.Html
    - .Editor()
        - .ForModel()
    - .BeginForm()
    - .Partial
        - .PartialAsync()
- @Html.ActionLink()

### Tag Helpers

- Use these instead of HTML Helpers
- <partial>
    - Model
    - Name

### View Components

- Partial view with attached code
- Shorthand possible
    - </> as instead of <></>
- Parts
    - Class
        - ViewComponent
    - Result
        - View
- Invoke
    - IViewComponentResult
    - InvokeAsync()
- Don't handle requests
- Typically initialize model
- Views location
    - Shared
        - Components
            - RegisteredStudentSomeDataViewModel
                - default.cshtml
- Usage
    - In code: MyCoolViewComponent
    - In cshtml: my-cool-view-component

### Interpretation

- Special symbols are HTML encoded
    - Can be avoided with @Html.Raw(data)
- String joined to @ is automatically interpreted as an email
    - Due to legacy reasons
    - Avoided with brackets ()
- To put a literal @, use @@
- @ -> code
- @: -> text
- Code by default unless a tag or @:

### Execution order

- Action
- View
- Layout

## Application Flow, Filters, and Middleware

### Misc

- TempData
- Controller
    - [Authorize(Role = "Admin")]
    - ControllerContext
        - ActionDescriptor
        - HttpContext
        - ModelState
        - RouteData
        - ValidProviderFactories
- Request
    - Id
        - For logging
    - Context
- Configuration providers
    - appsettings.json
        - .Development
        - .Production
    - launchsettings.json
- Don't forget to put  the project in the dev environment to get pretty error visualizations

#### Environments
- Dev
    -  Development
- Test
    - Testing & verification
- Stage
    - Customer tests
- Production
    - Release

### Application Flow

- Request
- Middleware
    - HTTP pipeline components
- Routing
    - Action
    - Page
- Controller initialization
    - Controller factory
    - Controller action invoker
- Action execution
    - Model binding
    - Model validation
    - Action
        - Filters
        - Execution
        - filters
        - result
- Result execution
    - Result
        - Filters
        - Execution
        - Filters
- View engine
- Response

### Error Handling

- Exception filter
- Model validation
    - ModelState
- Custom exception handling
    - app.UseExceptionHandler()
        - For exceptions
    - app.UseExceptionHandlerWithReExecute()
        - For non-exception errors
- Status code pages
    - app.UseStatusCodePagesWithRedirects()

### Middleware

- Software assembled into an app pipeline
- Each component
    - Handles requests and responses
    - Chooses whether to pass on to the next component or short-circuit
    - Can perform work before or after the next component in the pipeline
    - At invocation it receives the next component in the pipeline to decide whether to invoke it or not
        - Action<HttpContext, RequestDelegate> requestDelegate
    RequestDelegates build the pipeline
- Custom middleware class
- Registered in Configure()

#### Types

- Use()
    - Can short-circuit
    - Can pass to the next one
    - Can do work before or after the next one
- Run()
    - Terminates the pipeline
    - Runs last
- Map()
    - Branches the pipeline

#### Examples

```C#
public void Configure(IApplicationBuilder app, IWebHostEnvironment environment)
{
    // Route
    app.Map("/welcome", app =>
    {
        app.UseWelcomePage();

        app.Map("/someRoute", app => ...);
        app.Run(...);
    });

    // RequestDelegate 1
    app.Use(async (context, next)=>
    {
        await context.Response.WriteAsync("1");
        await next();
        await context.Response.WriteAsync("4");
    });

    // RequestDelegate 2
    app.Use(async (context, next)=>
    {
        await context.Response.WriteAsync("2");
        await next();
        await context.Response.WriteAsync("3");
    });

    // Always runs last
    app.Run(async (request)=>
    {
        await context.Response.WriteAsync("Always last");
    });
}
```

### Filters

#### Misc

- Run code before or after specific stages in the __Request Processing Pipeline__
- Come after the middleware
- Can be registered as an attribute
    - Put on controller, it applies to all actions
    - Can be put on a single action
- TypeFilterAttribute
- ServiceFilterAttribute
- Pattern: Chain of responsibility
- Can be
    - Synchronous
        - OnExecuting
        - OnExecuted
    - Asynchronous
        - OnExecutionAsync

#### Registration

- Global
    - Before and after every action
    - Startup.cs -> services.AddControllersWithViews(configure => configure.Filters.Add(new MyCustomFilter()));
    - Startup.cs -> services.AddControllersWithViews(configure => configure.Filters.Add(typeof (MyCustomFilter)));
- Attribute
    - : ActionFilterAttribute
    - : ExceptionFilterAttribute
    - : ResultFilterAttribute
    - : FormatFilterAttribute

#### Types

- Authorization
    - : IAuthorizationFilter
    - OnAuthorization
- Resource
    - : IResourceFilter
    - OnResourceExecuting
    - OnResourceExecuted
- Action
    - : IActionFilter
    - OnActionExecuting
    - OnActionExecuted
- Exception
    - : IExceptionFilter
    - OnExceptionExecuting
    - OnExceptionExecuted
- Result
    - : IResultFilter
    - OnResultExecuting
    - OnResultExecuted

#### Flow

- Request
- Middleware
- Authorization filters
- Resource filters
- Model binding/validation
- Action filters
- Action invocation
- Action filters
- Exception filters
- Result filters
- Result
- Result filters
- Resource filters
- Authorization filters
- Response