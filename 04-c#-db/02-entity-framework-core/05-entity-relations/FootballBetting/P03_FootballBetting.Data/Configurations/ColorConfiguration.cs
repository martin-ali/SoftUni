namespace P03_FootballBetting.Data.Configurations
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using P03_FootballBetting.Data.Models;

    public class ColorConfiguration : IEntityTypeConfiguration<Color>
    {
        public void Configure(EntityTypeBuilder<Color> builder)
        {
            builder
            .HasMany(c => c.PrimaryKitTeams)
            .WithOne(t => t.PrimaryKitColor)
            .HasForeignKey(t => t.PrimaryKitColorId)
            .OnDelete(DeleteBehavior.Restrict);

            builder
            .HasMany(c => c.SecondaryKitTeams)
            .WithOne(t => t.SecondaryKitColor)
            .HasForeignKey(t => t.SecondaryKitColorId)
            .OnDelete(DeleteBehavior.Restrict);
        }
    }
}