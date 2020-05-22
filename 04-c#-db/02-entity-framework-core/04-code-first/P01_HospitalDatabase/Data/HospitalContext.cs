namespace P01_HospitalDatabase.Data
{
    using Microsoft.EntityFrameworkCore;
    using P01_HospitalDatabase.Data.Models;

    public class HospitalContext : DbContext
    {
        public DbSet<Doctor> Doctors { get; set; }

        public DbSet<Patient> Patients { get; set; }

        public DbSet<Visitation> Visitations { get; set; }

        public DbSet<Diagnose> Diagnoses { get; set; }

        public DbSet<Medicament> Medicaments { get; set; }

        public DbSet<PatientMedicament> PatientMedicaments { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=NOTEBOOK-WIN;Database=HospitalDatabase;Integrated Security=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PatientMedicament>(entity =>
            {
                entity.HasKey(e => new { e.PatientId, e.MedicamentId });

                entity
                .HasOne(e => e.Patient)
                .WithMany(e => e.Prescriptions)
                .HasForeignKey(e => e.PatientId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK_PatientMedicaments_Patients");

                entity
                .HasOne(e => e.Medicament)
                .WithMany(e => e.Prescriptions)
                .HasForeignKey(e => e.MedicamentId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK_PatientMedicaments_Medicaments");
            });
        }
    }
}