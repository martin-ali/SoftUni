using System;
using System.Collections.Generic;

namespace trainers_salary
{
    class Program
    {
        static void Main()
        {
            int numberOfLectures = int.Parse(Console.ReadLine());
            decimal budget = decimal.Parse(Console.ReadLine());
            var woot = new Dictionary<string, decimal>
            {
                ["Jelev"] = 0,
                ["RoYaL"] = 0,
                ["Roli"] = 0,
                ["Trofon"] = 0,
                ["Sino"] = 0,
                ["Others"] = 0
            };

            for (int i = 0; i < numberOfLectures; i++)
            {
                var trainer = Console.ReadLine();
                if (woot.ContainsKey(trainer))
                {
                    woot[trainer] += budget / numberOfLectures; ;
                }
                else
                {
                    woot["Others"] += budget / numberOfLectures;
                }
            }

            foreach (var trainer in woot)
            {
                Console.WriteLine($"{trainer.Key} salary: {trainer.Value:0.00} lv");
            }
        }
    }
}
