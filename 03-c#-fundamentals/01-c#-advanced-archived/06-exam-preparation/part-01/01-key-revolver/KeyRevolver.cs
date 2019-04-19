using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace _01_key_revolver
{
    class KeyRevolver
    {
        static void Main()
        {
#if DEBUG
            Console.SetIn(new StreamReader("tests/test1.txt"));
#endif

            var bulletPrice = int.Parse(Console.ReadLine());
            var gunBarrelSize = int.Parse(Console.ReadLine());
            var bullets = new Stack<int>(Console.ReadLine().Split().Select(int.Parse));
            var locks = new Queue<int>(Console.ReadLine().Split().Select(int.Parse).ToList());
            var intelligence = int.Parse(Console.ReadLine());

            var bulletsFired = 0;
            while (locks.Count > 0 && bullets.Count > 0)
            {
                var bullet = bullets.Pop();
                var @lock = locks.Peek();

                bulletsFired++;
                if (@lock >= bullet)
                {
                    Console.WriteLine("Bang!");
                    locks.Dequeue();
                }
                else
                {
                    Console.WriteLine("Ping!");
                }

                if (bulletsFired % gunBarrelSize == 0 && bullets.Count > 0)
                {
                    Console.WriteLine("Reloading!");
                }
            }

            if (locks.Count == 0)
            {
                var moneyEarned = intelligence - (bulletsFired * bulletPrice);
                Console.WriteLine($"{bullets.Count} bullets left. Earned ${moneyEarned}");
            }
            else if (bullets.Count == 0)
            {
                Console.WriteLine($"Couldn't get through. Locks left: {locks.Count}");
            }
        }
    }
}
