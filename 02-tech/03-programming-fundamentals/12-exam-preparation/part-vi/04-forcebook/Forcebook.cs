using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace _04_forcebook
{
    class Forcebook
    {
        static void Main()
        {
            #if DEBUG
            var testNumber = Console.ReadLine();
            Console.SetIn(new StreamReader($"tests/test{testNumber}.txt"));
            #endif

            var forceUsersBySide = new SortedDictionary<string, List<string>>();

            var input = Console.ReadLine();
            while (input != "Lumpawaroo")
            {
                // Create
                if (input.Contains('|'))
                {
                    var query = input.Split(new[] { " | " }, StringSplitOptions.RemoveEmptyEntries);
                    var side = query[0];
                    var user = query[1];

                    bool forceUserExists = forceUsersBySide.Any(f => f.Value.Contains(user));
                    if (forceUserExists == false)
                    {
                        if (forceUsersBySide.ContainsKey(side) == false)
                        {
                            forceUsersBySide[side] = new List<string>();
                        }

                        forceUsersBySide[side].Add(user);
                    }
                }
                // Switch
                else
                {
                    var query = input.Split(new[] { " -> " }, StringSplitOptions.RemoveEmptyEntries);
                    var user = query[0];
                    var side = query[1];

                    forceUsersBySide.Any(f => f.Value.Remove(user));

                    if (forceUsersBySide.ContainsKey(side) == false)
                    {
                        forceUsersBySide[side] = new List<string>();
                    }

                    forceUsersBySide[side].Add(user);
                    Console.WriteLine($"{user} joins the {side} side!");
                }

                input = Console.ReadLine();
            }

            var orderedForceUsersBySide = forceUsersBySide
                                            .Where(f => f.Value.Count > 0)
                                            .OrderByDescending(f => f.Value.Count);

            foreach (var side in orderedForceUsersBySide)
            {
                Console.WriteLine($"Side: {side.Key}, Members: {side.Value.Count}");
                foreach (var forceUser in side.Value.OrderBy(f => f))
                {
                    Console.WriteLine($"! {forceUser}");
                }
            }
        }
    }
}
/*

Light | Gosho
Dark | Pesho
Lumpawaroo

Lighter | Royal
Darkest | Royal
Darker | DCay
Ivan Ivanov -> Lighter
DCay -> Lighter
Lumpawaroo

 */
