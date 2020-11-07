using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace TeisterMask.Data.Models.Configurations
{
    public class EmployeeConfiguration : IEntityTypeConfiguration<Employee>
    {
        public void Configure(EntityTypeBuilder<Employee> entity)
        {
            entity
            .HasMany(e => e.EmployeesTasks)
            .WithOne(et => et.Employee)
            .HasForeignKey(et => et.EmployeeId);
        }
    }
}