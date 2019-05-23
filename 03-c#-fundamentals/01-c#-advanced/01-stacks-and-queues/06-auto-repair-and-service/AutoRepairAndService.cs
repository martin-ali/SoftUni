using System;
using System.Collections.Generic;
using System.IO;

namespace _06_auto_repair_and_service
{
    class AutoRepairAndService
    {
        static void Main()
        {
#if DEBUG
            Console.SetIn(new StreamReader("tests/test4.txt"));
#endif

            var carsAwaitingService = new Queue<string>(Console.ReadLine().Split(' '));
            var servicedCars = new Stack<string>();

            var input = Console.ReadLine().Split('-');
            while (input[0] != "End")
            {
                if (input[0] == "Service" && carsAwaitingService.Count > 0)
                {
                    var car = carsAwaitingService.Dequeue();
                    Console.WriteLine($"Vehicle {car} got served.");

                    servicedCars.Push(car);
                }
                else if (input[0] == "CarInfo")
                {
                    var car = input[1];
                    if (carsAwaitingService.Contains(car))
                    {
                        Console.WriteLine("Still waiting for service.");
                    }
                    else
                    {
                        Console.WriteLine("Served.");
                    }
                }
                else if (input[0] == "History")
                {
                    Console.WriteLine(string.Join(", ", servicedCars));
                }

                input = Console.ReadLine().Split('-');
            }

            if (carsAwaitingService.Count > 0)
            {
                Console.WriteLine($"Vehicles for service: {string.Join(", ", carsAwaitingService)}");
            }

            Console.WriteLine($"Served vehicles: {string.Join(", ", servicedCars)}");
        }
    }
}
