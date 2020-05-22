# Entity Framework Introduction

## Notes

- IQueryable(Expression<Func>) vs IEnumerable(Func)
- IQueryable contains code and can be analyzed
- Lazy execution
- Once materialized, all other actions are performed outside the database
- Materialization comes last
- Data is downloaded only when the query is materialized/data is taken(ToList(), ToArray(), ToDictionary(), First(), Any(), Max(), etc...)
- Theory: It is materialized when the next method doesn't return IQueryable?
- Don't just go db.Towns, instead use db.Towns.Select() so you don't
download unnecessary data
- Always use Select()
- Only top level Select() materializes. Internal ones are part of the query
- Include() and Join() lower performance -> Use Select()
