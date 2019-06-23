using System;
using System.Linq;

namespace _04_froggy
{
    class StartUp
    {
        static void Main()
        {
            var stones = Console.ReadLine()
                            .Split(", ")
                            .Select(int.Parse);

            var lake = new Lake(stones);

            Console.WriteLine(string.Join(", ", lake));
        }
    }
}
