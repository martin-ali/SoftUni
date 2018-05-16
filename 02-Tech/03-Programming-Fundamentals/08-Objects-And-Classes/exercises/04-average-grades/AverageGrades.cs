using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace _04_average_grades
{
    class AverageGrades
    {
        static void Main()
        {
            #if DEBUG
            var testNumber = Console.ReadLine();
            Console.SetIn(new StreamReader($"tests/test{testNumber}.txt"));
            #endif

            var numberOfStudents = int.Parse(Console.ReadLine());
            var students = new Student[numberOfStudents];
            for (int i = 0; i < numberOfStudents; i++)
            {
                var studentParameters = Console.ReadLine().Split(' ');
                var name = studentParameters[0];
                var grades = studentParameters.Skip(1).Select(float.Parse);

                students[i] = new Student(name, grades);
            }

            var bestStudents = students
                                .Where(st => st.AverageGrade >= 5)
                                .OrderBy(st => st.Name)
                                .ThenByDescending(st => st.AverageGrade);
            foreach (var student in bestStudents)
            {
                Console.WriteLine($"{student.Name} -> {student.AverageGrade:0.00}");
            }
        }
    }

    internal class Student
    {
        public Student(string name, IEnumerable<float> grades)
        {
            Name = name;
            Grades = grades;
        }

        public string Name { get; private set; }

        public IEnumerable<float> Grades { get; private set; }

        public float AverageGrade
        {
            get
            {
                return this.Grades.Average();
            }
        }
    }
}
