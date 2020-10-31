namespace SoftJail.Data.Configurations
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using SoftJail.Data.Models;

    public class OfficerPrisonerConfiguration : IEntityTypeConfiguration<OfficerPrisoner>
    {
        public void Configure(EntityTypeBuilder<OfficerPrisoner> entity)
        {
            entity
            .HasKey(op => new { op.PrisonerId, op.OfficerId });

            entity
            .HasOne(op => op.Prisoner)
            .WithMany(p => p.PrisonerOfficers)
            .HasForeignKey(op => op.PrisonerId);

            entity
            .HasOne(op => op.Officer)
            .WithMany(o => o.OfficerPrisoners)
            .HasForeignKey(op => op.OfficerId);
        }
    }
}