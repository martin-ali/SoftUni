using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;

namespace _10_student_groups
{
    class StudentGroups
    {
        static void Main()
        {
#if DEBUG
            Console.SetIn(new StreamReader("test.txt"));
#endif

            var towns = new List<Town>();
            var input = Console.ReadLine();
            while (input != "End")
            {
                var town = Town.Read(input);
                input = Console.ReadLine();

                while (input.Contains("|"))
                {
                    var student = Student.Read(input);
                    town.Students.Add(student);

                    input = Console.ReadLine();
                }

                towns.Add(town);
            }

            var groups = Group.DistributeStudentsIntoGroups(towns);

            Console.WriteLine($"Created {groups.Count} groups in {towns.Count} towns:");

            foreach (var group in groups)
            {
                var studentMails = group.Students.Select(student => student.Email);
                Console.WriteLine($"{group.Town.Name} => {string.Join(", ", studentMails)}");
            }
        }
    }

    internal class Student
    {
        public Student(string name, string email, DateTime registrationDate)
        {
            Name = name;
            Email = email;
            RegistrationDate = registrationDate;
        }

        public string Name { get; private set; }

        public string Email { get; private set; }

        public DateTime RegistrationDate { get; private set; }

        public static Student Read(string rawData)
        {
            var studentData = rawData.Split(new char[] { ' ', '|' }, StringSplitOptions.RemoveEmptyEntries);

            var name = $"{studentData[0]} {studentData[1]}";
            var email = studentData[2];
            var registrationDate = DateTime.ParseExact(studentData[3], "d-MMM-yyyy", CultureInfo.InvariantCulture);

            return new Student(name, email, registrationDate);
        }

        public override string ToString()
        {
            return $"Name: {this.Name}, Email: {this.Email}, Registration date: {this.RegistrationDate:dd-MMM-yyyy}";
        }
    }

    internal class Town
    {
        public Town(string name, int seatsCount)
        {
            this.Name = name;
            this.SeatCount = seatsCount;
        }

        public string Name { get; private set; }

        public int SeatCount { get; private set; }

        public List<Student> Students { get; private set; } = new List<Student>();

        internal static Town Read(string rawData)
        {
            var data = rawData.Split(new string[] { " => ", " seats" }, StringSplitOptions.RemoveEmptyEntries);

            var townName = data[0];
            var seatCount = int.Parse(data[1]);

            return new Town(townName, seatCount);
        }

        public override string ToString()
        {
            return $"Name: {this.Name}, Seat count: {this.SeatCount}";
        }
    }

    internal class Group
    {
        public Group(Town town, IEnumerable<Student> students)
        {
            this.Town = town;
            this.Students = students;
        }

        public Town Town { get; private set; }

        public IEnumerable<Student> Students { get; private set; } = new List<Student>();

        public static List<Group> DistributeStudentsIntoGroups(List<Town> towns)
        {
            var groupedStudents = new List<Group>();
            foreach (var town in towns.OrderBy(t => t.Name))
            {
                var orderedTownStudents = town
                                            .Students
                                            .OrderBy(st => st.RegistrationDate)
                                            .ThenBy(st => st.Name)
                                            .ThenBy(st => st.Email);

                var groupCount = (int)Math.Ceiling((double)town.Students.Count / town.SeatCount);
                for (int i = 0; i < groupCount; i++)
                {
                    var studentGroup = orderedTownStudents.Skip(i * town.SeatCount).Take(town.SeatCount);
                    groupedStudents.Add(new Group(town, studentGroup));
                }
            }

            return groupedStudents;
        }
    }
}
