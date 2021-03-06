﻿namespace BattleCards.Data
{
    using BattleCards.Models;
    using Microsoft.EntityFrameworkCore;

    public class ApplicationDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Card> Cards { get; set; }
        public DbSet<UserCard> UserCards { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            optionsBuilder.UseSqlServer(DatabaseConfiguration.ConnectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserCard>
            (
                entity =>
                {
                    entity
                    .HasKey(uc => new { uc.UserId, uc.CardId });

                    entity
                    .HasOne(uc => uc.Card)
                    .WithMany(c => c.UserCards)
                    .HasForeignKey(uc => uc.CardId);

                    entity
                    .HasOne(uc => uc.User)
                    .WithMany(u => u.UserCards)
                    .HasForeignKey(uc => uc.UserId);
                }
            );


            base.OnModelCreating(modelBuilder);
        }
    }
}
