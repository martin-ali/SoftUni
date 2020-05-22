# JS Unit Testing and Modules Notes

## Error types

- Syntax
- Runtime
- Logical

## Exceptions/Errors

- Error
- RangeError
- TypeError
- ReferenceError

## Others

- Shit names are better than misleading names -> Func1 > CleanNames { MakePizzaAndNotCLeanNames }
- Duck typing

## Defensive programming

## Modules

- Data hiding

### Global scope

- In the browser all modules have the same global scope
- In Node.js all modules have their own global scope
- Variables are attached to it
    - Window.x = 1 is the same as:
        - var x = 1;
        - let x = 1;
        - const x = 1;

## Testing

- Unit
    - Should not be abstract
    - Be specific
    - 3A
- Integration
- UI
    - Selenium
- E2E
- API
- Screenshot

## Unit testing frameworks

- Mocha
    - Reporters
    - describe()
        - it()
        - before()
        - beforeEach()
- QUnit
- Unit.js
- Jasmine

## Assertion frameworks

- Chai
- Assert.js
- Should.js

## Mocking

- Sinon
- JMock
- Mockito
- Moq

## Parameters

- Implicit
    - arguments
    - this
- Explicit
    - Any parameter given to a function
