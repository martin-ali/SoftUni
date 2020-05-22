namespace P01_StudentSystem.Data
{
    using System;
    using Microsoft.EntityFrameworkCore;
    using P01_StudentSystem.Data.Enumerations;
    using P01_StudentSystem.Data.Models;

    public class DataSeeder
    {
        private ModelBuilder modelBuilder;

        public DataSeeder(ModelBuilder modelBuilder)
        {
            this.modelBuilder = modelBuilder;
        }

        public void SeedData()
        {
            this.SeedStudents();
            this.SeedCourses();
            this.SeedResources();
            this.SeedHomeworkSubmissions();
            this.SeedStudentCourses();
        }

        private void SeedStudents()
        {
            this.modelBuilder.Entity<Student>()
            .HasData(new[]
            {
                new Student
                {
                    StudentId = 1,
                    Name = "Pesho",
                    RegisteredOn = DateTime.Now
                },
                new Student
                {
                    StudentId = 2,
                    Name = "Gosho",
                    RegisteredOn = DateTime.Now.AddDays(2)
                },
                new Student
                {
                    StudentId = 3,
                    Name = "Stamat",
                    RegisteredOn = DateTime.Now.AddDays(-10)
                }
            });
        }

        private void SeedCourses()
        {
            this.modelBuilder.Entity<Course>()
            .HasData(new[]
            {
                new Course
                {
                    CourseId = 1,Name = "C#1",
                    StartDate = DateTime.Now,
                    EndDate = DateTime.Now.AddDays(7),
                    Price = 1000
                },
                new Course
                {
                    CourseId = 2,Name = "C#2",
                    StartDate = DateTime.Now,
                    EndDate = DateTime.Now.AddDays(7),
                    Price = 1000
                },
                new Course
                {
                    CourseId = 3,Name = "C#3",
                    StartDate = DateTime.Now,
                    EndDate = DateTime.Now.AddDays(7),
                    Price = 1000
                },
                new Course
                {
                    CourseId = 4,Name = "C#4",
                    StartDate = DateTime.Now,
                    EndDate = DateTime.Now.AddDays(7),
                    Price = 1000
                },
                new Course
                {
                    CourseId = 5,Name = "JS1",
                    StartDate = DateTime.Now,
                    EndDate = DateTime.Now.AddDays(7),
                    Price = 1000
                }
            });
        }

        private void SeedResources()
        {
            this.modelBuilder.Entity<Resource>()
            .HasData(new[]
            {
                new Resource
                {
                    ResourceId = 1,
                    Name = "Important document",
                    Url = "/docs",
                    ResourceType = ResourceType.Document,
                    CourseId = 1
                },
                new Resource
                {
                    ResourceId = 2,
                    Name = "Important stuff",
                    Url = "/misc",
                    ResourceType = ResourceType.Other,
                    CourseId = 2
                },
                new Resource
                {
                    ResourceId = 3,
                    Name = "Important presentation",
                    Url = "/presentations",
                    ResourceType = ResourceType.Presentation,
                    CourseId = 3
                },
                new Resource
                {
                    ResourceId = 4,
                    Name = "Important video",
                    Url = "/vids",
                    ResourceType = ResourceType.Video,
                    CourseId = 1
                },
            });
        }

        private void SeedHomeworkSubmissions()
        {
            this.modelBuilder.Entity<Homework>()
            .HasData(new[]
            {
                new Homework
                {
                    HomeworkId = 1,
                    Content = "Code",
                    ContentType = ContentType.Application,
                    SubmissionTime = DateTime.Now,
                    StudentId = 1,
                    CourseId = 1
                },
                new Homework
                {
                    HomeworkId = 2,
                    Content = "Document",
                    ContentType = ContentType.Pdf,
                    SubmissionTime = DateTime.Now,
                    StudentId = 2,
                    CourseId = 3
                },
                new Homework
                {
                    HomeworkId = 3,
                    Content = "Project",
                    ContentType = ContentType.Zip,
                    SubmissionTime = DateTime.Now,
                    StudentId = 3,
                    CourseId = 1
                },
            });
        }

        private void SeedStudentCourses()
        {
            this.modelBuilder.Entity<StudentCourse>()
            .HasData(new[]
            {
                new StudentCourse{StudentId = 1, CourseId = 3},
                new StudentCourse{StudentId = 2, CourseId = 2},
                new StudentCourse{StudentId = 3, CourseId = 1},
                new StudentCourse{StudentId = 1, CourseId = 1},
                new StudentCourse{StudentId = 3, CourseId = 2},
            });
        }
    }
}