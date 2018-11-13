using System;
using System.Collections.Generic;

namespace _05_hot_potato
{
    class HotPotato
    {
        static void Main()
        {
            var participants = new Queue<string>(Console.ReadLine().Split());
            var tossCount = int.Parse(Console.ReadLine());

            while (participants.Count > 1)
            {
                for (int i = 1; i < tossCount; i++)
                {
                    var participantToRotate = participants.Dequeue();
                    participants.Enqueue(participantToRotate);
                }

                var hotPotato = participants.Dequeue();
                Console.WriteLine($"Removed {hotPotato}");
            }

            Console.WriteLine($"Last is {participants.Dequeue()}");
        }
    }
}
/*

Mimi Pepi Toshko
2

Gosho Pesho Misho Stefan Krasi
10

Gosho Pesho Misho Stefan Krasi
1

*/
