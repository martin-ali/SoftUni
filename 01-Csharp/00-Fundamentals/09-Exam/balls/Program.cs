using System;
using System.Collections.Generic;

namespace balls
{
    class Program
    {
        static void Main()
        {
            var getPoints = new Dictionary<string, int>
            {
                ["red"] = 5,
                ["orange"] = 10,
                ["yellow"] = 15,
                ["white"] = 20,
            };

            var ballCount = new Dictionary<string, int>
            {
                ["red"] = 0,
                ["orange"] = 0,
                ["yellow"] = 0,
                ["white"] = 0,
                ["black"] = 0
            };

            var otherBalls = 0;

            int numberOfBalls = int.Parse(Console.ReadLine());
            var points = 0;
            for (int i = 0; i < numberOfBalls; i++)
            {
                var ball = Console.ReadLine().ToLower();
                if (getPoints.ContainsKey(ball))
                {
                    points += getPoints[ball];
                    ballCount[ball]++;
                }

                if (ball == "black")
                {
                    points /= 2;
                    ballCount[ball]++;
                }

                if (ballCount.ContainsKey(ball) == false)
                {
                    otherBalls++;
                }
            }

            Console.WriteLine($"Total points: {points}");
            Console.WriteLine($"Points from red balls: {ballCount["red"]}");
            Console.WriteLine($"Points from orange balls: {ballCount["orange"]}");
            Console.WriteLine($"Points from yellow balls: {ballCount["yellow"]}");
            Console.WriteLine($"Points from white balls: {ballCount["white"]}");
            Console.WriteLine($"Other colors picked: {otherBalls}");
            Console.WriteLine($"Divides from black balls: {ballCount["black"]}");
        }
    }
}
