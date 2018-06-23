using System;

namespace _02_passed_or_failed
{
    class PassedOrFailed
    {
        static void Main()
        {
            double grade = double.Parse(Console.ReadLine());
            var result = (grade >= 3 ? "Passed!" : "Failed!");
            Console.WriteLine(result);
        }
    }
}
