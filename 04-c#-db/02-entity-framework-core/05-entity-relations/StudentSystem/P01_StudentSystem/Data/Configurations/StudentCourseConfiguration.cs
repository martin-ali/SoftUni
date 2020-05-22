namespace P01_StudentSystem.Data.Configuration
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using P01_StudentSystem.Data.Models;

    public class StudentCourseConfiguration : IEntityTypeConfiguration<StudentCourse>
    {
        public void Configure(EntityTypeBuilder<StudentCourse> model)
        {
            model.HasKey(m => new { m.StudentId, m.CourseId });

            model
            .HasOne(m => m.Student)
            .WithMany(m => m.CourseEnrollments)
            .HasForeignKey(m => m.StudentId);

            model
            .HasOne(m => m.Course)
            .WithMany(m => m.StudentsEnrolled)
            .HasForeignKey(m => m.CourseId);
        }
    }
}