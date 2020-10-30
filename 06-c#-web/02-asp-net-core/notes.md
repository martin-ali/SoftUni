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

## Razor Views

### Misc

- Partial views
- HTML Helpers
- Client gets only HTML
    - All logic is handled server-side
- Views have access to loads of stuff
- HSTS

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
