# JS Advanced Notes

## Data Types

- String
- Number
- Boolean
- Undefined
- Null
- BigInt
    - Integer
    - Arbitrary precision
    - Not mixable with Number
    - Incompatible with class Math
- Symbol
    - Globally unique
        - Like GUID
    - Immutable
    - Primitive
- Object
    - Array

## Weakly Typed

- The value has a type, not the variable

## Variable declaration

- let
- const
- var

## Functions

- Arrow functions can't access "arguments" array
- Also can be hoisted
- Alway return undefined

### Declarations

- Function Declaration
```JS
function func() {}
```
- Function Expression
```JS
const myFuncVar = function func() {}
```
- Arrow Function
```JS
const myFuncVar = () => {}
```

## Operators

## Booleans

- Truthy
- Falsy

## Comparison

- == -> Equal value
    - Type coercion
    - Compares truthy-falsy values
- === -> Equal value and type