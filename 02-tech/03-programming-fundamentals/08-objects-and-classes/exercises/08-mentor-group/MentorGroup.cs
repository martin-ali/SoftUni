using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;

namespace _08_mentor_group
{
    class MentorGroup
    {
        static void Main()
        {
#if DEBUG
            Console.SetIn(new StreamReader("test.txt"));
#endif

            char[] separators = new char[] { ' ', ',' };
            var users = new SortedDictionary<string, Student>();
            var input = Console.ReadLine().Split(separators, StringSplitOptions.None);
            while (input[0] != "end")
            {
                var user = input[0];
                var dates = input.Skip(1).Select(date => DateTime.ParseExact(date, "dd/MM/yyyy", CultureInfo.InvariantCulture));

                if (users.ContainsKey(user) == false) users[user] = new Student(user);

                users[user].AddAttendances(dates);

                input = Console.ReadLine().Split(separators, StringSplitOptions.None);
            }

            input = Console.ReadLine().Split('-');
            while (input[0] != "end of comments")
            {
                var user = input[0];
                var comment = input[1];

                if (users.ContainsKey(user))
                {
                    users[user].AddComment(comment);
                }

                input = Console.ReadLine().Split('-');
            }

            foreach (var student in users)
            {
                Console.WriteLine($"{student.Key}");
                Console.WriteLine("Comments:");
                student.Value.Comments.ForEach(comment => Console.WriteLine($"- {comment}"));
                Console.WriteLine("Dates attended:");
                student.Value.Attendances.OrderBy(date => date).ToList().ForEach(date => Console.WriteLine($"-- {date:dd/MM/yyyy}"));
            }
        }
    }

    internal class Student
    {
        public Student(string name)
        {
            this.Name = name;
        }

        public string Name { get; private set; }

        public List<string> Comments { get; private set; } = new List<string>();

        public List<DateTime> Attendances { get; private set; } = new List<DateTime>();

        public void AddAttendances(IEnumerable<DateTime> attendances)
        {
            this.Attendances.AddRange(attendances);
        }

        public void AddComment(string comment)
        {
            this.Comments.Add(comment);
        }
    }
}
