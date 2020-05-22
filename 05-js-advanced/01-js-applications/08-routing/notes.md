# JS Routing Notes

## Terms

- History
    - event popstate
        - Fired when switching between states
```JS
history.pushState('State1', 'title', '/books/1');

window.addEventListener('popstate', event => {
    console.log(event.state) // MyState
});
```
- Sammy.js
- Syntactic sugar vs syntactic pattern
