using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace TeisterMask.Data.Models.Configurations
{
    public class TaskConfiguration : IEntityTypeConfiguration<Task>
    {
        public void Configure(EntityTypeBuilder<Task> entity)
        {
            entity
            .HasOne(t => t.Project)
            .WithMany(p => p.Tasks)
            .HasForeignKey(t => t.ProjectId);

            entity
            .HasMany(t => t.EmployeesTasks)
            .WithOne(et => et.Task)
            .HasForeignKey(et => et.TaskId);
        }
    }
}