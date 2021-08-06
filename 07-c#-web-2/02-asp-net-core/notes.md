# ASP .NET Core

## Introduction
- [Video](https://www.youtube.com/watch?v=pcQ-FpGxkTY)

- Enable Razor runtime compilation
- Data is returned in JSON bt default
- Convention over configuration
- Model binding
- FormModel
- !ModelState.IsValid
- Tag helpers
- Partial views
- {id?} - optional action parameter
- Query string - simple types (primitive)
- Form - complex types
- Action selectors
- Static files
- Identity System
- WebAppIdentity.dll
- Add -> Razor view -> with model
- All public methods in a controller are actions

## Razor Views
- [Video](https://www.youtube.com/watch?v=GgF9FO648oM)

### Razor
- Data in ViewData is escaped
    - Use Html.Raw()
- @:
    - Raw text mode
- @
    - C# mode
- @**@
    - Comment
- @@
    - Escaping
- Dependency injection
    - @inject

- @RenderBody()
- @RenderSection(name, mandatory)
- @addTagHelper()

- Underscore naming convention for all common views
- Inner views are rendered first
- ViewStart
- ViewImports

### HTML Helpers
    - Older
    - HTML-unfriendly

### Tag Helpers
    - Newer
    - HTML-friendly

### Partial Views

### View Components

- Like a partial view, but with code behind it

## Application Flow
- [Video](https://www.youtube.com/watch?v=Qqc5HmC4hUw)

### Fundamentals

- Pipeline
    - Extensible and modifiable
- Environment
- Configuration

### Misc

- Don't unnecessarily write async methods
    - Especially in ASP.NET Core
- Controllers contain request-response-related logic
- Services contain business logic
- Services shouldn't return viewmodels - either return the base model or service models
- No point in using repository pattern?

## Working With Data
- [Video](https://www.youtube.com/watch?v=nE5utQrOQiM)

### Model Binding

- Mapping request parameters to a action method parameters
- Don't name it "model" due to a bug when the model has a member named "Model"
- If it fails, no exceptions are thrown. Use ModelState to check for them

#### Data Sources

- Form values
- Route values
- Query strings
- Headers

### Model Validation

- Server-side validation is mandatory

### Points of interest

- Rename DbContext
- DataConstants
- using static DataConstants
- Properties under constructor
- Cascade issues (0:31)
- Automatic migration and ApplicationBuilder extensions (0:33)
- Clean up usings
- Viewmodel naming: Used in form? FormModel; Used in view? ViewModel
- Multiple select
- col-md vs col-sm, etc...
- offset-md
- Network -> disable cache
- heading-margin
- Categories (1:27)
- GitHub issues system
- \[Url\]
- if viewmodel is invalid, return same view with viewmodel and errors
- [MinLength] -> [StringLength] with custom error messages
- asp-validation-summary="all"
- [BindRequired]
- Custom validation attributes
- IValidatableObject
- Refresh, don't just return a particular view so the user doesn't resend the form on refresh (2:08)
- enctype, multiple files (2:27)
- If image == null, form likely isn't set to the right enctype
- MultipleActiveResultSets (2:43)
- Categories as enum is a bad idea (2:47)
- Images folder on the file system doesn't scale well
- Commit often, on small steps
- EF protects from SQL injection
- Category info (2:59)

### Misc

- Controller validation
- Database ignores \[Range\]
- Error messages constants
- Look over automapping
- Image size limit
- Constants for model annotations
- Image extension validation in controller

## Workshop 1
- [Video](https://www.youtube.com/watch?v=JbBNt-Oz1lM)

### Misc

- UserManager
- Repository pattern might be useless for the project
- Bootstrap card title
- Bootstrap carousel
- Jumbotron
- ListingViewModel
- QueryModel

## Web API

### Formats

- JSON
- XML

### AJAX

- Set of development techniques
- Common in SPAs

### Web API
- [Video](https://www.youtube.com/watch?v=LKp4fZMepxk)

### Angular

### CORS

- Has to be explicitly enabled
- Fully configurable

### Misc

- Attribute routing is mandatory
- Inherits BaseController
- Automatic ModelState.IsValid validation and status code return
- ProblemDetails
- IActionResult vs ActionResult<T>
- [ProducesResponseType]
    - Documentation generation metadata
- CreatedAtAction
- SPA VS Server-Side Rendering Application
- [Route("{id}")]
- ApiController
- RequestModel
- swapi.dev for json data
- Seed users with UserManager
- If the service model and view model are identical, the view model becomes redundant
- 3:15 for UsersController

### Structure

- Controllers - web
- Services - business logic
- DbContext - data

## Project Architecture
- [Video](https://www.youtube.com/watch?v=X1nkLHJOgEg)

### Monolithic
- Services communicate over enterprise services bus
- Just one application

### SOA
- Legacy

### Microservices
- Services communicate directly
- Dedicated data store per server

### Razor Pages
- Model and controller in one place
- Identity was uses it
- Similar to viewcomponents
- [BindProperty]

### Area
- MVC chunk in a folder
- Endpoints.MapControllerRoute - 1:35
- =Home or :exists
- Admin - 1:43
- EndpointRouteBuilderExtensions

### Automapper

### Repository Pattern
- Might not be needed

### Databases And ORM
- ORM vs micro-ORM
- Relational(SQL) vs non-relational(NoSQL)

### Misc
- WebConstants
- AdminConstants
- Hosted service/background tasks
- Mailgun, Sendgrid
- Default area

## Testing
- [VideO](https://www.youtube.com/watch?v=irzG1BH3WuI)

### Types
#### Unit
#### Component
#### Integration
- Most bang for your buck
### System
### Regression
### Acceptance
### Load
### Security
#### End-to-End

### Frameworks
#### XUnit
- [Fact]
- [Theory]
    - [InlineData()]
#### MyTested (preferred)
#### Selenium
#### Playwright
#### Cypress IO

### Mocking
- Moq
- FakeItEasy (preferred)

### Assertion libraries
- Shouldly
- Fluent Assertions

### Misc
- *AngleSharp* (for HTML)
- In-memory provider / SQLite for database mocking
- Arrange, Act, Assert (with comments)
- **AutoValidateAntiForgeryTokenAttribute**
- At the start, Ivo goes through the requirements
- Use Azure
- Should primarily use integration testing for the project
- Test project structure follows web project structure

## Advanced Topics

### WebHost

### Logging
#### Categories
- ILogger<Cars>
#### Types
- Trace
- Debug
- Information
- Warning
- Error
- Critical

### Cache
- Large performance increase
- Common target is home page
- <cache> tag helper
#### Types
- In-memory - IMemoryCache
- Distributed - IDistributedCache
- HTTP cache - Cache-Control - [ResponseCache]

### Sessions
- Saved on client
- String only

### Temp Data
- Saved until read, then deleted

### Post-Redirect-Get
- Reduce duplicate form submissions
- Answer post with redirect
- Redirect should trigger a get

### Areas

### Performance
- Compression
- Minification
- Caching
- CDN

### SEO

### GDPR

### Misc
- Home page with several categories - best, hottest, newest, etc...
- RoleManager
- ImageSharp
- To() -> MapTo()
- AdminAll view
- 2:17 - 1:1 becoming 1:many (use fluent api instead)
- No way to load an image into an input

## Workshop 2

- "View more" button
- Delete view
- If admin show buttons
- Order all items in list views
- CarsService -> Cars
- By ingredient search
- ViewModel naming
- IWriterService
- Add categories
- If a form has no action, it defaults to the one it came from
- Edit in service returns bool
- RecipeIsAuthoredBy
- Edit null check
- SignInManager, UserManager, RolesManager
- Try to make the viewcomponent for measurement units synchronous
- Become author - get full name
- Add some GitHub issues
- Categories - appetizer, main course, dessert
- Seed roles
- 1:47 - how to do async in non-async method
```C#
Task
.Run(async () => {})
.GetAwaiter()
.GetResult();
```
- Admin approves writer applications
- 2:04 - validation scripts
- Validation all
- Partials don't have sections
- Maybe make instance methods that don't require instance members into static ones?
- FormModel is web logic, services shouldn't accept it (maybe AddCarServiceModel?)
