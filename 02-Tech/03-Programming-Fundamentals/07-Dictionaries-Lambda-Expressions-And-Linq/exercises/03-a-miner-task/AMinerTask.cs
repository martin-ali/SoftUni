using System;
using System.Collections.Generic;

namespace _03_a_miner_task
{
    class AMinerTask
    {
        static void Main()
        {
            var storage = new Dictionary<string, int>();

            var input = Console.ReadLine();
            while (input != "stop")
            {
                var resource = input;
                var quantity = int.Parse(Console.ReadLine());

                if (storage.ContainsKey(resource) == false)
                {
                    storage[resource] = 0;
                }

                storage[resource] += quantity;
                input = Console.ReadLine();
            }

            foreach (var resource in storage)
            {
                Console.WriteLine($"{resource.Key} -> {resource.Value}");
            }
        }
    }
}
