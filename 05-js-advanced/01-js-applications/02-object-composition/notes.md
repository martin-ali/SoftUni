# JS Object Composition Notes

## Object composition

- Combining simple objects into complex one
- Forms
    - Aggregation
    - Concatenation
    - Delegation

## Closure

## Module patterns

- Module
- Revealing

## Destructuring

## Function generator

## Inheritance

- Classical
    - Function
    - new Student()
- Object
    - Object.create(student)

## Prototype

- Classes
    - Parent class or null
- Object literal
    - Null

## Miscellaneous

- Avoid ">" in CSS selectors

```JS
const rect = {
    height: 5,
    width: 5,
    area()
    {
        return this.width * this.height
    },
    compareTo(other)
    {
        const result = this.area() - other.area;

        return result || (this.width - other.width);
    }
}
```
