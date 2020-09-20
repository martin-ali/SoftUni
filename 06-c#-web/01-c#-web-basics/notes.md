# C# Web Basics Notes

## Misc

- AHK press E for melee, hold E to interact
- Началото на есента и началото на зимата има много позиции
- Януари е чудесен момент да си търся работас
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

## Misc

- Port header
- Difference between asynchronous and multi-threaded programming
- Multitasking
- Handles
    - Open resources

## Process

- Priority

## Thread

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

## Promises

## Task

- Task scheduler
- Not a thread, but rather a unit of work to be done
- Generally tasks > threads in terms of efficiency and performance
- Uses Thread under the hood
