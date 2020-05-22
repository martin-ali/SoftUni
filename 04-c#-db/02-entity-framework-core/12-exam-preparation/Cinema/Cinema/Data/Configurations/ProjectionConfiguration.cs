namespace Cinema.Data.Configurations
{
    using Cinema.Data.Models;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class ProjectionConfiguration : IEntityTypeConfiguration<Projection>
    {
        public void Configure(EntityTypeBuilder<Projection> entity)
        {
            entity
            .HasOne(p => p.Movie)
            .WithMany(m => m.Projections)
            .HasForeignKey(p => p.MovieId);

            entity
            .HasOne(p => p.Hall)
            .WithMany(h => h.Projections)
            .HasForeignKey(p => p.HallId);

            entity
            .HasMany(p => p.Tickets)
            .WithOne(t => t.Projection)
            .HasForeignKey(t => t.ProjectionId);
        }
    }
}