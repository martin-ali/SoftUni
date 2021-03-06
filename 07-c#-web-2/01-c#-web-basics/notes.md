# C# Web Basics Notes

## Web Server HTTP Protocol

### Work Model
- Web Client
- Web Server

### HTTP

#### Methods

#### Status Codes
- 1xx - Information
- 2xx - Success
- 3xx - Redirect
- 4xx - Client Error
- 5xx - Server Error

#### Request
- Request Line
    - Method
    - URI
    - Protocol version
- Request Headers
    - Additional parameters
- Request Body
    - Data
    - Form fields
- Data
    - Query string format
        - Unlimited data through HTTP

#### Response
- Data
    - Body

### HTML Forms

### URL
- Uniform Resource Locator
- **Protocol**://**Host**:**Port**/**Path**?**Query string**#**Fragment**

### MIME
- Multi-Purpose Mail Extensions
- Type of media
- Multipart messages

### Misc
- Encoding
    - Data translated to something the browser can understand

## Asynchronous Processing
- [Video](https://www.youtube.com/watch?v=m5-hYdj40So)
- [More information](https://github.com/ivaylokenov/C-Sharp-Async-Await-In-Detail)

### Synchronous Programming

### Asynchronous Programming
- Asynchronous vs multithreaded programming

### Threads
- System.Thread
- Start()
- Join()
    - Await selected thread
- Dedicated stack per thread
- Race conditions
- Thread safety
    - Lock
- Exceptions can only be handled in their respective threads

### Tasks
- new Task()
- Task.Run()
- Task.Factory.StartNew()
- Task.WhenAll()
- async/await

### Parallelism and Concurrency
- System.Collections.Concurrent
- Parallel LINQ
- Parallelism has overhead
    - Pointless for small numbers of tasks

### Misc
- Enable Razor Runtime Compilation

## State Management
- [Video](https://www.youtube.com/watch?v=LBs_heQouUo)

#### Cookies
- Dictionary
    - Name, value, attributes
    - Attributes not in requests
- Permanent until explicitly deleted
- Expiry date
- Cookie header
- Set-Cookie header
- Third-party cookies

##### Uses
- State management
- Personalization
- Tracking

#### Session
- Saved on server, unlike cookie

## Workshop 1
- [Video](https://www.youtube.com/watch?v=4iF8bDURsMg)
- Ivo's Github -> CSharp-Multithreading
- Encoding
    - Default ascii
- Content length
- Content type
- Browsers make 2 requests (site and favicon)
- No reason to put "Async" in method names when *all* your methods are async

## MVC Introduction
- [Video](https://www.youtube.com/watch?v=EKdijAGEZI8)

### MVC Components
#### Model
- Data Access Layer
- Classes that describe the data works with
- Primarily data representation
#### View
- Presentation Layer
- Master views
- Sub views
#### Controller
- Processes requests
- Actions

### CSHTML

### Misc
- Nullable

## MVC Advanced - View Engine
- [Video](https://www.youtube.com/watch?v=k1UKk5PLxVU)

## Exam Practice
- [Video](https://www.youtube.com/watch?v=HzRD2WE8qhk)
- By default, don't put virtual on collections or foreign keys
## Project Ideas
- Car Loans
- Posts
- Learning
