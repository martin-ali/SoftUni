using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace TeisterMask.Data.Models.Configurations
{
    public class ProjectConfiguration : IEntityTypeConfiguration<Project>
    {
        public void Configure(EntityTypeBuilder<Project> entity)
        {
            entity
            .HasMany(e => e.Tasks)
            .WithOne(t => t.Project)
            .HasForeignKey(t => t.ProjectId);
        }
    }
}