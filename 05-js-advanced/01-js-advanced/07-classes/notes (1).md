# JS Classes Notes

## This

- With no "." in front, it uses Window as "this"

## Declaration

- Class declaration
- Class expression
    - Can be anonymous

## Innards

- Constructor
    - Just one
- Methods
    - Static
    - .toString()
- Fields
    - Public
    - Private
- Accessor properties
    - Get
    - Set
- Inheritance
```JS
class Dog extends Animal
```
- Base constructor
```JS
constructor(name)
{
    super(name);
}
```

## Prototype

- Common link between all instances
- Used so not every instance needs a copy of every function and the like
_ .__proto__
- Arrow functions don't have prototypes

## Unit Testing

- Mocha
- Chai
