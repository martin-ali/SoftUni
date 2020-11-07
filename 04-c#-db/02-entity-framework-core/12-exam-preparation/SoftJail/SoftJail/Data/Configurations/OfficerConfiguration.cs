namespace SoftJail.Data.Configurations
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using SoftJail.Data.Models;

    public class OfficerConfiguration : IEntityTypeConfiguration<Officer>
    {
        public void Configure(EntityTypeBuilder<Officer> entity)
        {
            entity
            .HasOne(o => o.Department)
            .WithMany(d => d.Officers)
            .HasForeignKey(o => o.DepartmentId);

            entity
            .HasMany(o => o.OfficerPrisoners)
            .WithOne(op => op.Officer)
            .HasForeignKey(op => op.OfficerId);
        }
    }
}