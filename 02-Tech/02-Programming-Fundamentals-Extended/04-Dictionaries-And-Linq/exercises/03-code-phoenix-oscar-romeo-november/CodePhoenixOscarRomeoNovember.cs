using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace _03_code_phoenix_oscar_romeo_november
{
    class CodePhoenixOscarRomeoNovember
    {
        static void Main()
        {
            #if DEBUG
            Console.SetIn(new StreamReader("tests/test3.txt"));
            #endif

            var squadsByLeader = new Dictionary<string, HashSet<string>>();

            // get input
            var input = Console.ReadLine();
            while (input != "Blaze it!")
            {
                var data = input.Split(new[] { " -> " }, StringSplitOptions.RemoveEmptyEntries);
                var leader = data[0];
                var member = data[1];

                if (squadsByLeader.ContainsKey(leader) == false)
                {
                    squadsByLeader[leader] = new HashSet<string>();
                }

                squadsByLeader[leader].Add(member);

                input = Console.ReadLine();
            }

            // Filter leaders
            var squadSizeByLeader = new Dictionary<string, int>();
            foreach (var squad in squadsByLeader)
            {
                var leader = squad.Key;
                squadSizeByLeader[leader] = 0;

                foreach (var member in squad.Value)
                {
                    // Both leaders' squads contain each other
                    if (squadsByLeader.ContainsKey(member)
                        && squadsByLeader[member].Contains(leader))
                    {
                        continue;
                    }

                    squadSizeByLeader[leader]++;
                }
            }

            // Print
            var orderedSquadCountByLeader = squadSizeByLeader
                                            .OrderByDescending(x => x.Value);
            foreach (var squad in orderedSquadCountByLeader)
            {
                var leader = squad.Key;
                var memberCount = squad.Value;

                Console.WriteLine($"{leader} : {memberCount}");
            }
        }
    }
}
