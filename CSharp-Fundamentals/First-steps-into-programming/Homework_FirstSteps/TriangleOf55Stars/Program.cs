using System;

namespace TriangleOf55Stars
{
    class Program
    {
        static void Main(string[] args)
        {
            var starsRow = "";
            for (int starsCount = 1; starsCount <= 10; starsCount++)
            {
                Console.WriteLine(starsRow += "*");
            }
        }
    }
}
