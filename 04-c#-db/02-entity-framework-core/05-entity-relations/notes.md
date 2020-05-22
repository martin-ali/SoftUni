# Entity Relations Notes

## Information

- Object composition
- Navigation properties
- Make migrations small, often, and with less changes, so they can be easily understood
- InverseProperty
- Not the best idea to use only attributes
- Index -> Fast search
- Shadow properties -> Opposite of [NotMapped]
- Do not validate through setter -> properties should always be auto-properties
- Always check if (optionsBuilder.IsConfigured == false) in OnConfiguring()
- context.Database.Migrate() does not create migrations, it merely processes them

## Split configuration

- Split OnModelCreating() -> Lecture at 1h:20m
- StudentConfiguration : IEntityTypeConfiguration<Student>
