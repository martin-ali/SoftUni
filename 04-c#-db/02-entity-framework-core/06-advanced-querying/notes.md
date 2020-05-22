# Advanced Querying Notes

## Information

- Benchmark.NET
- Hot and cold queries
- Repeated queries are cached
- Compiled queries
- Entity tracking
    - Attach()
    - Entry().State = EntityState.Detached
- Stored procedure
- Bulk operations with Entity Framework Plus
- Loading
    - Explicit
    - Eager
    - Lazy
- Concurrency
    - Optimistic (Last wins, can be switched to first wins)

## Optimizations

- FromSqlRaw() vs FromSqlInterpolated()
- Create new Car {Id = 1} to update car without requesting it

## Query Internals

- Model Validation/Analysis -> Migrations, etc., always executed once on first query, usually takes 1-5s
- Cold Query
    - Analyze LINQ(Expression tree)
    - Translate to SQL
    - Execute
    - Build result to POCO
- Warm Query
    - Analyze LINQ(Expression tree)
    - Get SQL from cache
    - Execute
    - Build result to POCO
- Compiled Query(Put them in "Queries" folder)
    - Get SQL from cache
    - Execute
    - Build result to POCO
