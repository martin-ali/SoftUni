# JS This Notes

## Execution

- Initial pass
    - Checks for syntax errors

## This

- Function context
    - object that owns the currently executed code

- Function invocation
    - "Free-floating" function
    - Not attached to an object(not a method)
    - func()
    - this -> global object
- Method invocation
    - object.func()
    - this -> object of invocation
- Constructor invocation
    - new Student()
    - this -> newly created instance
- Event handler
    - button.click()
    - this -> owner of event(not event target)
- Indirect invocation
    - call()
        - this -> given first parameter
        - all other arguments are passed to the function
    - apply()
        - this -> given first parameter
        - second argument is array with arguments to pass to the function
    - bind()
        - student.bind(dog.bark)
        - Creates entirely new function
        - Once bound, it cannot change its context
            - Even with call(), apply(), or bind()
        - this -> object caller
- Arrow functions
    - Has no own context
    - Takes the context of the function where it was defined(Retains lexical scope)
- Inner functions
    - Same as function invocation

## This(strict mode)

- Function invocation
    - this -> undefined
