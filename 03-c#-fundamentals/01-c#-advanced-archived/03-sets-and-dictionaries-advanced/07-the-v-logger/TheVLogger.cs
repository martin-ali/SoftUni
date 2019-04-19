using System;
using System.Collections.Generic;
using System.Linq;

namespace _07_the_v_logger
{
    class TheVLogger
    {
        static void Main()
        {
            // Set up
            var followersByVlogger = new Dictionary<string, HashSet<string>>();
            var followedByVlogger = new Dictionary<string, HashSet<string>>();

            // Execute
            var command = Console.ReadLine();
            while (command != "Statistics")
            {
                var commandData = command.Replace(" joined The V-Logger", "").Split(" followed ");

                if (commandData.Length == 1 && followersByVlogger.ContainsKey(commandData[0]) == false)
                {
                    var newVlogger = commandData[0];
                    followersByVlogger[newVlogger] = new HashSet<string>();
                    followedByVlogger[newVlogger] = new HashSet<string>();
                }
                else if (commandData.Length > 1)
                {
                    var followerVlogger = commandData[0];
                    var followedVlogger = commandData[1];

                    if (followerVlogger != followedVlogger
                        && followersByVlogger.ContainsKey(followerVlogger)
                        && followersByVlogger.ContainsKey(followedVlogger))
                    {
                        followersByVlogger[followedVlogger].Add(followerVlogger);
                        followedByVlogger[followerVlogger].Add(followedVlogger);
                    }
                }

                command = Console.ReadLine();
            }

            // Set up data for printing
            var index = 1;
            var vloggersOrdered = followersByVlogger
                                    .OrderByDescending(vlogger => followersByVlogger[vlogger.Key].Count)
                                    .ThenBy(vlogger => followedByVlogger[vlogger.Key].Count);
            var mostFamousVlogger = vloggersOrdered.First().Key;
            var vloggers = vloggersOrdered.Skip(1);

            Console.WriteLine($"The V-Logger has a total of {followersByVlogger.Count} vloggers in its logs.");

            // Print most famous vlogger
            Console.WriteLine($"{index++}. {mostFamousVlogger} : {followersByVlogger[mostFamousVlogger].Count} followers, {followedByVlogger[mostFamousVlogger].Count} following");

            foreach (var follower in followersByVlogger[mostFamousVlogger].OrderBy(vlogger => vlogger))
            {
                Console.WriteLine($"*  {follower}");
            }

            // Print everyone else
            foreach (var vlogger in vloggers)
            {
                Console.WriteLine($"{index++}. {vlogger.Key} : {followersByVlogger[vlogger.Key].Count} followers, {followedByVlogger[vlogger.Key].Count} following");
            }
        }
    }
}
/*

EmilConrad joined The V-Logger
VenomTheDoctor joined The V-Logger
Saffrona joined The V-Logger
Saffrona followed EmilConrad
Saffrona followed VenomTheDoctor
EmilConrad followed VenomTheDoctor
VenomTheDoctor followed VenomTheDoctor
Saffrona followed EmilConrad
Statistics

JennaMarbles joined The V-Logger
JennaMarbles followed Zoella
AmazingPhil joined The V-Logger
JennaMarbles followed AmazingPhil
Zoella joined The V-Logger
JennaMarbles followed Zoella
Zoella followed AmazingPhil
Christy followed Zoella
Zoella followed Christy
JacksGap joined The V-Logger
JacksGap followed JennaMarbles
PewDiePie joined The V-Logger
Zoella joined The V-Logger
Statistics

 */
