using System;
using System.Text.RegularExpressions;
using System.Linq;
using System.IO;
using System.Collections.Generic;

namespace _07_query_mess
{
    class QueryMess
    {
        static void Main()
        {
            #if DEBUG
            var testNumber = Console.ReadLine();
            Console.SetIn(new StreamReader($"tests/test{testNumber}.txt"));
            #endif

            const string fieldAndValuePattern = @"([^&?]+)=([^&?]+)";
            const string cleaningPattern = @"( |%20|\+)+";

            var input = Console.ReadLine();
            while (input != "END")
            {
                var cleanInput = Regex.Replace(input, cleaningPattern, " ");
                var matches = Regex.Matches(cleanInput, fieldAndValuePattern);

                var valuesByField = new Dictionary<string, List<string>>();
                foreach (Match match in matches)
                {
                    var field = match.Groups[1].Value.Trim();
                    var value = match.Groups[2].Value.Trim();

                    if (valuesByField.ContainsKey(field) == false)
                    {
                        valuesByField[field] = new List<string>();
                    }

                    valuesByField[field].Add(value);
                }

                foreach (var field in valuesByField)
                {
                    Console.Write($"{field.Key}=[{string.Join(", ", field.Value)}]");
                }

                Console.WriteLine();

                input = Console.ReadLine();
            }
        }
    }
}