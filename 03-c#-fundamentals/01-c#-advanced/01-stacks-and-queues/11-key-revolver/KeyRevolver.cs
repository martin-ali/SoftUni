using System;
using System.Collections.Generic;
using System.Linq;

namespace _11_key_revolver
{
    class KeyRevolver
    {
        static void Main()
        {
            var bulletPrice = int.Parse(Console.ReadLine());
            var barrelSize = int.Parse(Console.ReadLine());
            var bullets = new Stack<int>(Console.ReadLine().Split().Select(int.Parse));
            var locks = new Queue<int>(Console.ReadLine().Split().Select(int.Parse));
            var intelligence = int.Parse(Console.ReadLine());

            var bulletsShot = 0;
            while (bullets.Count > 0 && locks.Count > 0)
            {
                bulletsShot++;
                var bullet = bullets.Pop();
                var @lock = locks.Peek();

                if (bullet <= @lock)
                {
                    Console.WriteLine("Bang!");
                    locks.Dequeue();
                }
                else
                {
                    Console.WriteLine("Ping!");
                }

                if (bulletsShot % barrelSize == 0 && bullets.Count != 0)
                {
                    Console.WriteLine("Reloading!");
                }
            }

            if (locks.Count == 0)
            {
                var earnings = intelligence - (bulletPrice * bulletsShot);
                Console.WriteLine($"{bullets.Count} bullets left. Earned ${earnings}");
            }
            else
            {
                Console.WriteLine($"Couldn't get through. Locks left: {locks.Count}");
            }
        }
    }
}
