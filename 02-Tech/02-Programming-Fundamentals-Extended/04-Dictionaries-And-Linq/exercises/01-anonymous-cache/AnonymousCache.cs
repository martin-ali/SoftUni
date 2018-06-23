using System;
using System.Collections.Generic;
using System.Linq;

namespace _01_anonymous_cache
{
    public static class Extensions
    {
        public static void Deconstruct<T>(this IList<T> list, out T first, out T second, out T third)
        {

            first = list.Count > 0 ? list[0] : default(T);
            second = list.Count > 1 ? list[1] : default(T);
            third = list.Count > 2 ? list[2] : default(T);
        }
    }

    class AnonymousCache
    {
        public static void Main()
        {
            var data = new Dictionary<string, Dictionary<string, long>>();
            var cache = new Dictionary<string, Dictionary<string, long>>();

            var line = Console.ReadLine();
            while (line != "thetinggoesskrra")
            {
                if (line.Contains("->"))
                {
                    var (dataKey, dataSize, dataSet) = line.Split(new char[] { '-', '>', ' ', '|' }, StringSplitOptions.RemoveEmptyEntries);

                    if (data.ContainsKey(dataSet))
                    {
                        data[dataSet][dataKey] = long.Parse(dataSize);
                    }
                    else
                    {
                        if (cache.ContainsKey(dataSet) == false)
                        {
                            cache[dataSet] = new Dictionary<string, long>();
                        }

                        cache[dataSet][dataKey] = long.Parse(dataSize);
                    }
                }
                else
                {
                    data[line] = new Dictionary<string, long>();

                    if (cache.ContainsKey(line))
                    {
                        data[line] = cache[line];
                        // cache.Remove(line);
                    }
                }

                line = Console.ReadLine();
            }


            if (data.Count > 0)
            {
                // var biggestDataSet = data.Aggregate((setA, setB) => setA.Value.Values.Sum() > setB.Value.Values.Sum() ? setA : setB);
                var biggestDataSet = data.OrderByDescending(x => x.Value.Values.Sum()).First();
                Console.WriteLine($"Data Set: {biggestDataSet.Key}, Total Size: {biggestDataSet.Value.Values.Sum()}");

                var dataKeys = biggestDataSet.Value.Keys;
                foreach (var dataKey in dataKeys)
                {
                    Console.WriteLine($"$.{dataKey}");
                }
            }
        }
    }
}
