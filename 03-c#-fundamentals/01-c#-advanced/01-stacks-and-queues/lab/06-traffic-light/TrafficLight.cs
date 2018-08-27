using System;
using System.Collections.Generic;

namespace _06_traffic_light
{
    class TrafficLight
    {
        static void Main()
        {
            var carsThatCanPass = int.Parse(Console.ReadLine());
            var cars = new Queue<string>();
            var carsThatPassed = 0;

            var command = Console.ReadLine();
            while (command != "end")
            {
                if (command == "green")
                {
                    for (int i = 0; cars.Count > 0 && i < carsThatCanPass; i++)
                    {
                        var car = cars.Dequeue();
                        Console.WriteLine($"{car} passed!");
                        carsThatPassed++;
                    }
                }
                else // command is a car
                {
                    var car = command;
                    cars.Enqueue(car);
                }

                command = Console.ReadLine();
            }

            Console.WriteLine($"{carsThatPassed} cars passed the crossroads.");
        }
    }
}
/*

4
Hummer H2
Audi
Lada
Tesla
Renault
Trabant
Mercedes
MAN Truck
green
green
Tesla
Renault
Trabant
end

3
Pesho's car
Gosho's car
Mercedes CLS
Nekva troshka
green
BMW X5
green
end

*/
