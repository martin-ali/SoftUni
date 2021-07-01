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
