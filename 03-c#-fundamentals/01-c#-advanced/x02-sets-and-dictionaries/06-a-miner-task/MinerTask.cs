using System;
using System.Collections.Generic;

namespace _06_a_miner_task
{
    class MinerTask
    {
        static void Main()
        {
            var quantityByResource = new Dictionary<string, int>();

            var command = Console.ReadLine();
            while (command != "stop")
            {
                var resource = command;
                var quantity = int.Parse(Console.ReadLine());

                if (quantityByResource.ContainsKey(resource) == false)
                {
                    quantityByResource[resource] = 0;
                }

                quantityByResource[resource] += quantity;

                command = Console.ReadLine();
            }

            foreach (var resource in quantityByResource)
            {
                Console.WriteLine($"{resource.Key} -> {resource.Value}");
            }
        }
    }
}
