# C# Web Basics Notes

## Misc

- AHK press E for melee, hold E to interact
- Началото на есента и началото на зимата има много позиции
- Януари е чудесен момент да си търся работа
- admin@nikolay.it

## HTTP Protocol

### HTTP

- Text-based
- Status codes
    - 1xx - Information
    - 2xx - Success
    - 3xx - Redirect
    - 4xx - Client error
    - 5xx - Server error
- Needs a network of some sort to work
- Client
    - Browsers
    - Apps
    - Consoles apps
- Server
    - Console app
- Stateless
    - Cookies
- Client initiates communication
- Components
    - Method / request type
    - Headers
        - Keep-Alive
            - Reuse TCP connection, don't close it
        - Content-Type
        - Content-Length (MIME type)
            - Bytes
        - Set-Cookie
    - Status code

- Structure of a request
    - Method
    - Resource
    - Protocol version
    - Headers (all following lines as "key: value")
    - Newline (size - 2B)
    - Body
- Structure of a response
    - Protocol version
    - Status code
    - Status text
    - Headers
    - Newline
    - Body
    - Newline
- HTTPS
    - SSL
    - HLS
- Newline - always \r\n

### Types

- GET
- POST
    - Unlike GET, has a body

### Web

- UTF-8
    - Symbols can be 1, 2, 3, or 4 bytes long
- Ports
- REST
- CORS
- What we call a certificate is a combination of a public and a private key
    - Public key
        - Everyone knows
    - Private key
        - Only server knows
- The connection between a byte array and text is called encoding - the rules of how to transform bytes into symbols

### C#

- Loopback (Localhost)
- HttpClient
- Encoding.Utf8
- Let's Encrypt offers free certificates that expire after 3 months
- Socket
    - IP
    - Port
- Environment.NewLine

### URL

- Up to 2048 characters
- Structure - (protocol)://(subdomain).(domain/host):(port)/(resource)?(query string)#(fragment)
- Escaped by % encoding

## Asynchronous Processing

### Misc

- Port header
- Difference between asynchronous and multi-threaded programming
- Multitasking
- Handles
    - Open resources

### Process

- Priority

### Thread

- Main thread
    - Usually the UI thread
    - When it dies, it terminates the whole process
- Call stack (memory area)
    - Contains all method calls
    - Variables
- Current instruction
- Memory
- 1MB stack
- Child threads are owned by their parent thread
- A connection between threads is done using a variable of type Thread
- Thread C# class
- Thread creation is slow
- Race conditions
- Lock
    - Object
        - Unique identifier
    - Monitor
- Worker threads ignore try-catch
    - Exceptions cannot be handled outside a thread

### Promises

### Task

- Task scheduler
- Not a thread, but rather a unit of work to be done
- Generally tasks > threads in terms of efficiency and performance
- Uses Thread under the hood

### Parallelism

- Data parallelism
- Degree of parallelism

### Concurrency

- Thread-safe collections

## Web Server - State Management

### Misc

- All timezones are converted to UTC
    - Unix timestamp
    - RTC
- Browsers will create additional requests for favicons if one isn't provided

### Cookies

- Saved by browser
- Sent in a header every time
- Session management
- Personalization
- Tracking
- Headers
    - Set-Cookie
    - Cookie
- Structure
    - Key
    - Value
    - Attribute (optional)
- Scope
    - Path
    - Domain
    - judge.softuni.bg
    - softuni.bg
    - .softuni.bg
- Lifetime
- Security
- Storage
    - RDBMS
        - Usually SQLite
- Encrypted cookies are encrypted and decrypted on the server. The browser stores and sends the encrypted version

### Session

- Cookie
- Session store

## Workshop 1

- .NET standard
    - Usable everywhere
    - Always use this
- C# strings are always unicode
    - 2 bytes per symbol
- using statics

## MVC Introduction

### Misc

- Architectural design pattern
- DbContext (repository)
- Entity
- Services
    - Example: GetLast5ForumPosts
    - Template services
    - Microservices *important*
- DTO (data transfer object)
- MVVM
- Single page application (SPA)
- Multi page application (MPA)
- Right click -> Properties -> Copy always
    - For non-code files
    - Otherwise the compiler ignores it

### Model

- *Data*
- Manipulation rules
- Validation rules
- Persistent data encapsulation
- Data access layer

### View

- *Presentation*
- Templates
- Used to generate HTML
- Defines UI
- Master views
    - layouts
- Sub-views
    - partial views
    - controls

### Controller

- *Function*
- Core components
- Processes requests
- Handles
    - Communication with the user
    - Application flow
    - Application-specific logic
- Actions

### Easily getting caller method name

Example 1:
```C#
public string GetCallerMethodName([CallerMemberName]string callerName = null)
{
    return callerName;
}
```

Example 2:
```C#
public HttpResponse View([CallerMemberName]string path = null)
{ ... }
```

## MVC Advanced - View Engine

### Misc

- XUnit
- NUnit
- Roslyn
    - NuGet -> Microsoft.CSharp.Analyzer
- .NET Standard
    - Най-малко общо кратно между .NET Core и .NET Framework
- coreclr.dll
- Streams have to be used as if they have a reading head
    - Once we're done writing, if we start to read, the reading will start from the position we stopped at

### HTML

### ViewModel

## Workshop 2

- All controller actions are public
- HTML form method
    - If GET, then data is appended to URL
    - If POST, then data is sent as body

## MVC Advanced - IOC and Data Binding

- SOLID
- Dependency container
    - Dependency dictionary
    - Create instance
- In ASP.NET action parameters come from the request (data binding)
    - Query parameters
    - Form parameters
- Data binding
- Convert.ChangeType()
- View model
    - Transfers data to views
- Input model
    - Gets data from view
    - Opposite of view model

## Workshop 3

- Services
    - They use the database through given parameters
    - Don't deal with requests or responses
- Controller -> Service -> Database

### Packages

- Microsoft.EntityFrameworkCore.SqlServer
    - For database
- Microsoft.EntityFrameworkCore.Design
    - For console commands

### Do not forget

- Set up the default startup project in Visual Studio
- Set up "copy always" for all static files
    - Views
    - Css
- Delete bin and obj
- Migrations
- Use logic to check validity and not attributes
- Check every page if user is logged
- Hidden inputs for the id and stuff
- Register the services
