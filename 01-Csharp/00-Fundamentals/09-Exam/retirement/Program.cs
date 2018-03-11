using System;
using System.Collections.Generic;

namespace retirement
{
    class Program
    {
        static Dictionary<string, (int age, int work)> map =
        new Dictionary<string, (int age, int work)>
        {
            ["male"] = (64, 38),
            ["female"] = (61, 35)
        };

        static void Main()
        {
            var gender = GetGenderOrNull(Console.ReadLine().ToLower());
            int age = Clamp(1, int.Parse(Console.ReadLine()), 10000);
            int work = Clamp(1, int.Parse(Console.ReadLine()), 10000);

            if (gender == null || age == -1 || work == -1)
            {
                Console.WriteLine("Invalid input.");
                return;
            }

            var experienceNeeded = map[gender];
            if (age >= experienceNeeded.age && work >= experienceNeeded.work)
            {
                Console.WriteLine($"Ready to retire at {age} and {work} years of experience!");
            }
            else if (age < experienceNeeded.age && work >= experienceNeeded.work)
            {
                Console.WriteLine($"Worked enough, but not old enough. Years left to retirement: {experienceNeeded.age - age}.");
            }
            else if (age >= experienceNeeded.age && work <= experienceNeeded.work)
            {
                Console.WriteLine($"Old enough, but haven't worked enough. Work experience left to retirement: {experienceNeeded.work - work}.");
            }
            else
            {
                Console.WriteLine($"Too early. Years left to retirement: {experienceNeeded.age - age}. Work experience left to retirement: {experienceNeeded.work - work}.");
            }
        }

        static string GetGenderOrNull(string input)
        {
            if (input == "male" || input == "female")
            {
                return input;
            }

            return null;
        }

        static int Clamp(int min, int input, int max)
        {
            if (input >= min && input <= max)
            {
                return input;
            }

            return -1;
        }
    }
}
