using System;
using System.Collections.Generic;

namespace _03_a_miner_task
{
    class AMinerTask
    {
        static void Main()
        {
            var storage = new Dictionary<string, int>();

            var line = Console.ReadLine();
            while (line != "stop")
            {

                var resource = line;
                var quantity = int.Parse(Console.ReadLine());

                if (storage.ContainsKey(resource) == false)
                {
                    storage[resource] = 0;
                }

                storage[resource] += quantity;
                line = Console.ReadLine();
            }

            foreach (var resource in storage)
            {
                Console.WriteLine($"{resource.Key} -> {resource.Value}");
            }
        }
    }
}
