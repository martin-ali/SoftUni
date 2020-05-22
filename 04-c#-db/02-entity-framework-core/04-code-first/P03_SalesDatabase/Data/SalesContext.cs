namespace P03_SalesDatabase.Data
{
    using Microsoft.EntityFrameworkCore;
    using P03_SalesDatabase.Data.Models;

    public class SalesContext : DbContext
    {
        public DbSet<Product> Products { get; set; }

        public DbSet<Customer> Customers { get; set; }

        public DbSet<Store> Stores { get; set; }

        public DbSet<Sale> Sales { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=NOTEBOOK-WIN;Database=SalesDatabase;Integrated Security=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>(pr =>
            {
                pr
                .Property(p => p.Description)
                .HasDefaultValue("No description");
            });

            modelBuilder.Entity<Sale>(s =>
            {
                s
                .Property(p => p.Date)
                .HasDefaultValueSql("GETDATE()");
            });
        }
    }
}