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
