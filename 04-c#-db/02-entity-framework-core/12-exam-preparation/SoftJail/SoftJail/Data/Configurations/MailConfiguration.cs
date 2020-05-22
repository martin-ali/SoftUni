namespace SoftJail.Data.Configurations
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using SoftJail.Data.Models;

    public class MailConfiguration : IEntityTypeConfiguration<Mail>
    {
        public void Configure(EntityTypeBuilder<Mail> entity)
        {
            entity
            .HasOne(m => m.Prisoner)
            .WithMany(p => p.Mails)
            .HasForeignKey(m => m.PrisonerId);
        }
    }
}