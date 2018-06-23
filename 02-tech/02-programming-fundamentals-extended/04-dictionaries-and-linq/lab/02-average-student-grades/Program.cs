using System;
using System.Collections.Generic;
using System.Linq;

namespace _02_average_student_grades
{
    public static class Extensions
    {
        public static void Deconstruct<T>(this IList<T> list, out T first, out T second)
        {

            first = list.Count > 0 ? list[0] : default(T);
            second = list.Count > 1 ? list[1] : default(T);
        }
    }

    class Program
    {
        static void Main()
        {
            var studentsAndGrades = new Dictionary<string, List<double>>();
            int numberOfLines = int.Parse(Console.ReadLine());
            // int numberOfLines = 7;

            for (int i = 0; i < numberOfLines; i++)
            {
                var (name, grade) = Console.ReadLine().Split(' ');
                if (studentsAndGrades.ContainsKey(name) == false)
                {
                    studentsAndGrades[name] = new List<double>();
                }

                studentsAndGrades[name].Add(double.Parse(grade));
            }

            var studentGradesFormatted = studentsAndGrades.Select(student =>
                $"{student.Key} -> {String.Join(" ", student.Value.Select(grade => $"{grade:0.00}"))} (avg: {student.Value.Average():0.00})");

            Console.WriteLine(String.Join("\n", studentGradesFormatted));
        }
    }
}