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


## Project Ideas
- Car Loans
- Posts
- Learning
