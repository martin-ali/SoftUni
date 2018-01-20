using System;

namespace Excellent_or_Not
{
    class Program
    {
        static void Main()
        {
            var grade = double.Parse(Console.ReadLine());

            Console.WriteLine(grade >= 5.5 ? "Excellent!" : "Not excellent.");
        }
    }
}
