# Design Patterns

## Information

- SOLID
- Abstraction
    - Raises complexity
    - Hide implementation details
- Encapsulation
    - Hide data
- Separation of concerns
- Cohesion and coupling
- Divide and conquer

## Drawbacks

- Do not lead to direct code reuse
- Deceptively simple
- Pattern overload/overdesign
- Validated by experience and discussion, not automated testing
- Should be used only if understood well

## Types

- Creational
    - Solve problems with object creation
        - Initialization
        - Configuration
    - Improve object creation approach
    - Do not use new
        - Can't change dependencies
        - Considered an antipattern
- Structural
    - Solve problems with class composition
        - Assembling objects
    - Inheritance - Vertical communication
    - Composition - way two classes communicate
        - Opposite of inheritance
        - One contains the other - Horizontal communication
- Behavioral
    - Behaviour and interactions between classes
    - Hide behaviour
    - Assign behaviour

## Patterns

- Creational
    - Singleton
        - Single instance
        - Not a global variable
        - In C#
            - Can implement interfaces, unlike static
    - Prototype
        - Create new objects by copying this prototype
        - When creating many identical objects
        - Like JavaScript
        - ICloneable
        - new vs .Clone()
        - .MemberwiseClone()
    - Factory Method
    - Abstract Factory
    - Builder
- Structural
    - Facade
        - Makes a complicated system easy to use
    - Composite
        - Different objects treated the same way
        - Don't care if my gift(SingleGift) is single or a collection(CompositeGift), I can always add it to an abstract collection and call .GetPrice()
            - Each gift will be named identically, calculate its value differently, but return an int
            - No need for DFS or BFS if I want to sum their prices
    - Adapter
    - Bridge
    - Decorator
    - Flyweight
    - Proxy
- Behavioural
    - Command
    - Template
    - Chain of Eesponsibility
    - Interpreter
    - Iterator
    - Mediator
    - Memento
    - Observer
    - State
    - Strategy
    - Template Method
    - Visitor
