using System;
using System.Collections.Generic;

namespace _10_crossroads
{
    class Crossroads
    {
        static void Main()
        {
            var greenLightSeconds = int.Parse(Console.ReadLine());
            var freeWindowSeconds = int.Parse(Console.ReadLine());

            var cars = new Queue<string>();
            var carsPassedCount = 0;
            var crashHappened = false;
            var input = default(string);
            var lastCar = default(string);
            var impactCharacter = default(char);

            while ((input = Console.ReadLine()) != "END")
            {
                if (input != "green")
                {
                    cars.Enqueue(input);
                    continue;
                }

                var secondsLeft = greenLightSeconds;
                while (cars.Count > 0 && secondsLeft > 0)
                {
                    lastCar = cars.Dequeue();
                    secondsLeft -= lastCar.Length;

                    carsPassedCount++;
                }

                secondsLeft += freeWindowSeconds;
                if (secondsLeft < 0)
                {
                    impactCharacter = lastCar[lastCar.Length + secondsLeft];
                    crashHappened = true;
                    break;
                }
            }

            if (crashHappened)
            {
                Console.WriteLine("A crash happened!");
                Console.WriteLine($"{lastCar} was hit at {impactCharacter}.");
            }
            else
            {
                Console.WriteLine("Everyone is safe.");
                Console.WriteLine($"{carsPassedCount} total cars passed the crossroads.");
            }
        }
    }
}

/*
10
5
Mercedes
green
Mercedes
BMW
Skoda
green
END

9
3
Mercedes
Hummer
green
Hummer
Mercedes
green
END
*/
