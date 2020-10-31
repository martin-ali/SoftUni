namespace Cinema.Data.Configurations
{
    using Cinema.Data.Models;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class HallConfiguration : IEntityTypeConfiguration<Hall>
    {
        public void Configure(EntityTypeBuilder<Hall> entity)
        {
            entity
            .HasMany(h => h.Projections)
            .WithOne(p => p.Hall)
            .HasForeignKey(p => p.HallId);

            entity
            .HasMany(h => h.Seats)
            .WithOne(s => s.Hall)
            .HasForeignKey(s => s.HallId);
        }
    }
}