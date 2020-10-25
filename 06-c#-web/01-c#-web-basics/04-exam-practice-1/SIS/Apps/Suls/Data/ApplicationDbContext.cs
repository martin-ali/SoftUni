using Microsoft.EntityFrameworkCore;

namespace Suls.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext() { }

        // Just in case anyone wants to configure
        public ApplicationDbContext(DbContextOptions options)
            : base(options) { }

        public DbSet<User> Users { get; set; }

        public DbSet<Problem> Problems { get; set; }

        public DbSet<Submission> Submissions { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (optionsBuilder.IsConfigured)
            {
                return;
            }

            // Integrated Security is used for allowing your Windows login to be used for SQL Server authentication
            optionsBuilder.UseSqlServer("Server=DESKTOP-7CR19M9\\SQLSERVERMARTI;Database=Suls;Integrated Security=True");
        }
    }
}