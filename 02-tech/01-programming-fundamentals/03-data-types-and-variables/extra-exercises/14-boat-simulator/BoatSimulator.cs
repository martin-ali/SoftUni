using System;

namespace _14_boat_simulator
{
    class BoatSimulator
    {
        static void Main()
        {
            var firstBoatSymbol = char.Parse(Console.ReadLine());
            var secondBoatSymbol = char.Parse(Console.ReadLine());
            var numberOfTurns = int.Parse(Console.ReadLine());

            var firstBoat = (symbol: firstBoatSymbol, speed: 0);
            var secondBoat = (symbol: secondBoatSymbol, speed: 0);

            for (int turn = 1; turn <= numberOfTurns; turn++)
            {
                var command = Console.ReadLine();
                if (command == "UPGRADE")
                {
                    firstBoat.symbol += (char)3;
                    secondBoat.symbol += (char)3;
                    continue;
                }

                var speed = command.Length;

                if (turn % 2 != 0)
                {
                    firstBoat.speed += speed;
                    if (firstBoat.speed >= 50)
                    {
                        break;
                    }
                }
                else
                {
                    secondBoat.speed += speed;
                    if (secondBoat.speed >= 50)
                    {
                        break;
                    }
                }
            }

            var winner = firstBoat.speed > secondBoat.speed ? firstBoat : secondBoat;
            Console.WriteLine(winner.symbol);
        }
    }
}
