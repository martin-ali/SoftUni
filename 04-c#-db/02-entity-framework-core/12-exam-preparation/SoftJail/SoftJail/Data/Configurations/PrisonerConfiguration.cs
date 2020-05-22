namespace SoftJail.Data.Configurations
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using SoftJail.Data.Models;

    public class PrisonerConfiguration : IEntityTypeConfiguration<Prisoner>
    {
        public void Configure(EntityTypeBuilder<Prisoner> entity)
        {
            entity
            .HasOne(p => p.Cell)
            .WithMany(c => c.Prisoners)
            .HasForeignKey(p => p.CellId);

            entity
            .HasMany(p => p.Mails)
            .WithOne(m => m.Prisoner)
            .HasForeignKey(m => m.PrisonerId);

            entity
            .HasMany(p => p.PrisonerOfficers)
            .WithOne(po => po.Prisoner)
            .HasForeignKey(po => po.PrisonerId);
        }
    }
}