# JS Rest Services And Ajax Notes

## HTTP

- Versions
    - 1.1
    - 2
        - Well supported
- Methods
    - Get
    - Post
    - Put
    - Delete
    - Patch
    - Head
    - Options
- Structure
    - Line
    - Headers
    - Body
- Response status codes
    - 1xx - Information
    - 2xx - Success
    - 3xx - Redirect (temporary/permanent)
    - 4xx - Client error
    - 5xx - Server error

## REST

- Architecture for client-server communication over HTTP
- Representational state transfer
- Gives a snapshot of the data at the exact time of request
- Not auto-refreshed
- Self-descriptive messages
    - Contains everything needed to process request
- Architectural constraints
    - Client-server architecture
    - *Statelessness*
    - Cacheable
    - Layered system
    - Code on demand (optional)
    - Uniform interface

## AJAX

- Asynchronous JavaScript and XML
- fetch()
    - Uses promises
    - Replaces legacy XMLHttpRequest
- clone()
- json()
- redirect()
- text()

## Miscellaneous

- Authentication
    - Verify identity
    - Are you Steven?
- Authorization
    - Verify permission
    - Can Steven enter the server room?
- Cross-origin request
    - CORS
    - Request towards different domain
        - a.com requests resource from b.com
    - Forbidden
