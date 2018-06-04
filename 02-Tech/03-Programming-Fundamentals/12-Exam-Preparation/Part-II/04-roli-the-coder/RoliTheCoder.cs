using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace _04_roli_the_coder
{
    class RoliTheCoder
    {
        private static string participantPattern = @"[A-Za-z0-9'-]+";

        private static string eventPattern = @".+?";

        private static string idPattern = @"\d+";

        private static Regex requestPattern = new Regex($@"^({idPattern}) #({eventPattern})( @{participantPattern})*$");

        static void Main()
        {
            var eventDataById = new Dictionary<string, (string name, HashSet<string> participants)>();

            var input = Console.ReadLine();
            while (input != "Time for Code")
            {
                if (requestPattern.IsMatch(input))
                {
                    var requestData = input.Split(new[] { " #", " " }, StringSplitOptions.RemoveEmptyEntries);
                    var id = requestData[0];
                    var eventName = requestData[1];
                    var participants = requestData.Skip(2);

                    if (eventDataById.ContainsKey(id) == false)
                    {
                        eventDataById[id] = (eventName, new HashSet<string>());
                    }

                    if (eventDataById[id].name == eventName)
                    {
                        eventDataById[id].participants.UnionWith(participants);
                    }
                }

                input = Console.ReadLine();
            }

            var orderedEventDataById = eventDataById
                                        .OrderByDescending(ev => ev.Value.participants.Count)
                                        .ThenBy(ev => ev.Value.name);
            foreach (var @event in orderedEventDataById)
            {
                Console.WriteLine($"{@event.Value.name} - {@event.Value.participants.Count}");

                var orderedParticipants = @event.Value.participants.OrderBy(p => p);
                foreach (var participant in orderedParticipants)
                {
                    Console.WriteLine(participant);
                }
            }
        }
    }
}
