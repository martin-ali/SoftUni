namespace SoftJail.Data.Configurations
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using SoftJail.Data.Models;

    public class CellConfiguration : IEntityTypeConfiguration<Cell>
    {
        public void Configure(EntityTypeBuilder<Cell> entity)
        {
            entity
            .HasOne(c => c.Department)
            .WithMany(d => d.Cells)
            .HasForeignKey(c => c.DepartmentId);

            entity
            .HasMany(c => c.Prisoners)
            .WithOne(p => p.Cell)
            .HasForeignKey(p => p.CellId);

            entity
            .HasIndex(c => c.CellNumber)
            .IsUnique(true);
        }
    }
}