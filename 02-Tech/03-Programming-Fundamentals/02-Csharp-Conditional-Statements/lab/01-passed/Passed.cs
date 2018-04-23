using System;

namespace _01_passed
{
    class Passed
    {
        static void Main()
        {
            double grade = double.Parse(Console.ReadLine());
            if (grade >= 3) Console.WriteLine("Passed!");
        }
    }
}
