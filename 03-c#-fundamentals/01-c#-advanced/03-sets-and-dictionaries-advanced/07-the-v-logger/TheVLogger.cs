using System;
using System.Collections.Generic;
using System.Linq;

namespace _07_the_v_logger
{
    class TheVLogger
    {
        static void Main()
        {
            var followersByVlogger = new Dictionary<string, HashSet<string>>();
            var followedByVlogger = new Dictionary<string, HashSet<string>>();
            var input = Console.ReadLine();
            while (input != "Statistics")
            {
                var command = input.Split();

                if (command.Length == 4)
                {
                    var vlogger = command[0];
                    if (followersByVlogger.ContainsKey(vlogger) == false)
                    {
                        followersByVlogger[vlogger] = new HashSet<string>();
                        followedByVlogger[vlogger] = new HashSet<string>();
                    }
                }
                else if (command.Length == 3)
                {
                    var follower = command[0];
                    var followed = command[2];

                    if (followersByVlogger.ContainsKey(follower)
                        && followersByVlogger.ContainsKey(followed)
                        && followed != follower)
                    {
                        followersByVlogger[followed].Add(follower);
                        followedByVlogger[follower].Add(followed);
                    }
                }

                input = Console.ReadLine();
            }

            Console.WriteLine($"The V-Logger has a total of {followersByVlogger.Count} vloggers in its logs.");
            var vloggersSorted = followersByVlogger
                                    .OrderByDescending(v => v.Value.Count)
                                    .ThenBy(v => followedByVlogger[v.Key].Count)
                                    .ToArray();

            for (int index = 0; index < vloggersSorted.Length; index++)
            {
                var vlogger = vloggersSorted[index].Key;
                Console.WriteLine($"{index + 1}. {vlogger} : {followersByVlogger[vlogger].Count} followers, {followedByVlogger[vlogger].Count} following");

                if (index == 0)
                {
                    foreach (var follower in followersByVlogger[vlogger].OrderBy(c => c))
                    {
                        Console.WriteLine($"*  {follower}");
                    }
                }
            }
        }
    }
}
