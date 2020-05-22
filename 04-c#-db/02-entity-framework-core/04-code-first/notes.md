# Code First Notes

## Information

- Key means id
- Strings are Unicode by default
- Property named "Id" or ClassName+"Id" is automatically considered [Key]
- enums should be given explicit numbers to avoid issues with IDs in databases after adding more and messing with their order
- using static
- Migration - snapshot what will change in db
- Migration - Up -> add, Down -> Remove
- Composite key -> lambda + anonymous object
- Benchmark.Net
- Fluent API vs attributes
- All non-nullable types are [Required]
- Type only becomes a table when it has a DbSet in DbContext

## Attributes

- Table(Name)
- Column(Type, Name)
- StringLength
- MinLength
- MaxLength
- Required
- Key
- ForeignKey

## Steps for creating a database

- Add models
- Add primary key -> Id
- Add other columns
- Add annotations
- Add DbContext + DbSet for every model
- OnConfiguring(ConnectionString) + OnModelCreating(Models)
- Foreign keys/Relationships -> TownId + Property Town Town(To make less queries) + Collection in the related model
- In many-to-many -> Written as 2 one-to-many relations
- context.Database.EnsureCreated()
- Add migration {Name} in Package Manager Console
- db.Database.Migrate()
- Queries
