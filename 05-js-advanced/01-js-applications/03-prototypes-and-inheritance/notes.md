# JS Prototypes And Inheritance Notes

## Method override

- Just shadows it

## Prototype

- __proto__
    - Internal
    - use Object.getPrototypeOf(obj) instead
- Every object has a link to a prototype
    - Does not necessarily _have_ a prototype
- .prototype
    - Only on functions and classes
    - Not on objects

## Inheritance

- Olden days 1
```JS
function Person(name)
{
    this.name = name;
}

function Teacher(name)
{
    Person.constructor(name)
}
```
- Olden days 2
```JS
Teacher.prototype = Object.create(Person.prototype)
```
