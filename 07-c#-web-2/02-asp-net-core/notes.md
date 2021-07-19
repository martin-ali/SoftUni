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

- Attribute routing is mandatory
- Inherits BaseController
- Automatic ModelState.IsValid validation and status code return
- ProblemDetails
- IActionResult vs ActionResult<T>
- [ProducesResponseType]
    - Documentation generation metadata
- CreatedAtAction

### Angular

### CORS

- Has to be explicitly enabled
- Fully configurable

### Misc

- SPA VS Server-Side Rendering Application
- [Route("{id}")]
