using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace TeisterMask.Data.Models.Configurations
{
    public class EmployeeTaskConfiguration : IEntityTypeConfiguration<EmployeeTask>
    {
        public void Configure(EntityTypeBuilder<EmployeeTask> entity)
        {
            entity
            .HasKey(et => new { et.EmployeeId, et.TaskId });

            entity
            .HasOne(et => et.Employee)
            .WithMany(e => e.EmployeesTasks)
            .HasForeignKey(et => et.EmployeeId);

            entity
            .HasOne(et => et.Task)
            .WithMany(t => t.EmployeesTasks)
            .HasForeignKey(et => et.TaskId);
        }
    }
}