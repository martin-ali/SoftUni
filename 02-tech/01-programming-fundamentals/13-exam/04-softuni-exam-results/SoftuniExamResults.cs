using System;
using System.Collections.Generic;
using System.Linq;

namespace _04_softuni_exam_results
{
    class SoftuniExamResults
    {
        static void Main()
        {
            var pointsByParticipant = new SortedDictionary<string, int>();
            var submissionCountByLanguage = new SortedDictionary<string, int>();

            var input = string.Empty;
            while ((input = Console.ReadLine()) != "exam finished")
            {
                var data = input.Split('-');
                var participant = data[0];

                if (data.Length == 3)
                {
                    var language = data[1];
                    var points = int.Parse(data[2]);

                    if (pointsByParticipant.ContainsKey(participant) == false)
                    {
                        pointsByParticipant[participant] = 0;
                    }

                    if (submissionCountByLanguage.ContainsKey(language) == false)
                    {
                        submissionCountByLanguage[language] = 0;
                    }

                    if (pointsByParticipant[participant] < points)
                    {
                        pointsByParticipant[participant] = points;
                    }

                    submissionCountByLanguage[language]++;
                }
                else // Ban
                {
                    pointsByParticipant.Remove(participant);
                }
            }

            Console.WriteLine("Results:");
            foreach (var participant in pointsByParticipant.OrderByDescending(x => x.Value))
            {
                Console.WriteLine($"{participant.Key} | {participant.Value}");
            }

            Console.WriteLine("Submissions:");
            foreach (var language in submissionCountByLanguage.OrderByDescending(x => x.Value))
            {
                Console.WriteLine($"{language.Key} - {language.Value}");
            }
        }
    }
}
