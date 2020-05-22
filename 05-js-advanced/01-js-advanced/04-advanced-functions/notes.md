# JS Advanced Functions Notes

## Functions

- First class
- .reduce()

```JS
const arr = [1, 2, 3];
const sum = arr.reduce((sum, current) => sum + current, 0);
```

## Terms

- First-class function
    - Treated like a variable
- Higher-order function
    - Takes a function as a parameter
    - Returns a function
- Partial application
    - Fixing a number of arguments to a function
- Closure
    - State is preserved in the outer function
    - Privileged members
        - Can access the hidden fields
- IIFE
    - Garbage collected soon after usage
- Pure function
    - No side effects
    - Only works with given data

## Currying

- Breaking a function into a series of function where each takes a single argument
- myFunc(1, 2, 3) => myFunc(1)(2)(3)
- Partial application

## This

- Function context
    - Object that owns the code

## Call

- .apply()
    - Object, parameters array
- .call()
    - Object, given parameters like params

## Remember

- Computer science lecture mentioned at 2:03:00
