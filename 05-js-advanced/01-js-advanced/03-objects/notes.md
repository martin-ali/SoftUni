# JS Advanced Objects Notes

## Object

- Object
    - .keys()
    - .values()
    - .freeze()
        -.isFrozen()
    - .seal()

## Keys

- No minus('-') symbol
- No numbers

## Access

- Dot notation
- Bracket notation

## Dont's

- Don't use *delete*
    - Extremely slow
    - Leads to bugs by breaking references
    - Set propery to _null_ instead
```JS
delete person.name
```