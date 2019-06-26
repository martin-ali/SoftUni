using System;
using System.Collections.Generic;
using System.Linq;

namespace _01_club_party
{
    class ClubParty
    {
        static void Main()
        {
            var hallMaxCapacity = int.Parse(Console.ReadLine());
            var hallsAndCrowds = new Stack<string>(Console.ReadLine().Split());

            var crowdsByHall = new Dictionary<string, Queue<int>>();
            var halls = new Queue<string>();
            var crowds = new Stack<int>();

            // while (hallsAndCrowds.Count > 0)
            while (hallsAndCrowds.Any())
            {
                var input = hallsAndCrowds.Pop();

                var itemIsHall = int.TryParse(input, out int crowd);
                if (itemIsHall == false)
                {
                    var newHall = input;

                    crowdsByHall[newHall] = new Queue<int>();
                    halls.Enqueue(newHall);

                    continue;
                }

                if (halls.Count == 0)
                {
                    continue;
                }

                var hallIndex = halls.Peek();
                var hall = crowdsByHall[hallIndex];

                var neededCapacity = hall.Sum() + crowd;
                if (neededCapacity > hallMaxCapacity)
                {
                    Console.WriteLine($"{halls.Dequeue()} -> {string.Join(", ", hall)}");
                    hallsAndCrowds.Push(input);

                    continue;
                }

                hall.Enqueue(crowd);
            }
        }
    }
}
/*

60
1 20 b 20 20 a

50
15 a 40 30 20 c 15 10 b

40
20 20 20 20 20 20 D F 15 5 M 26 38

*/
