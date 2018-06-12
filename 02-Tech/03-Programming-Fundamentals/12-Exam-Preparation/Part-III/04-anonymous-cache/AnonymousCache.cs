using System;
using System.Collections.Generic;
using System.Linq;

namespace _04_anonymous_cache
{
    class AnonymousCache
    {
        static void Main()
        {
            string[] separator = new[] { " -> ", " | " };
            var data = new Dictionary<string, Dictionary<string, long>>();
            var cache = new Dictionary<string, Dictionary<string, long>>();

            var input = Console.ReadLine().Split(separator, StringSplitOptions.RemoveEmptyEntries);
            while (input[0] != "thetinggoesskrra")
            {
                if (input.Length == 1)
                {
                    var dataSet = input[0];

                    data[dataSet] = cache.TryGetValue(dataSet, out Dictionary<string, long> cachedData)
                                    ? cachedData
                                    : new Dictionary<string, long>();
                }
                else
                {
                    var dataKey = input[0];
                    var dataSize = int.Parse(input[1]);
                    var dataSet = input[2];

                    if (data.ContainsKey(dataSet))
                    {
                        data[dataSet][dataKey] = dataSize;
                    }
                    else
                    {
                        if (cache.ContainsKey(dataSet) == false)
                        {
                            cache[dataSet] = new Dictionary<string, long>();
                        }

                        cache[dataSet][dataKey] = dataSize;
                    }
                }

                input = Console.ReadLine().Split(separator, StringSplitOptions.RemoveEmptyEntries);
            }

            if (data.Count == 0)
            {
                return;
            }

            var biggestData = data.OrderByDescending(d => d.Value.Values.Sum()).First();
            Console.WriteLine($"Data Set: {biggestData.Key}, Total Size: {biggestData.Value.Sum(d => d.Value)}");
            foreach (var dataSet in biggestData.Value)
            {
                Console.WriteLine($"$.{dataSet.Key}");
            }
        }
    }
}
/*

Users
BankAccounts
ADDB444 -> 23111 | BankAccounts
Students -> 2000 | Users
Workers -> 24233 | Users
thetinggoesskrra

Cars
Car1 -> 233333 | Cars
Car23 -> 266666 | Cars
Warehouse2 -> 10000 | Buildings
Warehouse3 -> 480000 | Buildings
Warehouse5 -> 100000 | Buildings
Buildings
thetinggoesskrra

 */
