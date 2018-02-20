using System;

namespace Excellent_Result
{
    class Program
    {
        static void Main()
        {
            var grade = double.Parse(Console.ReadLine());

            if (grade >= 5.5)
            {
                Console.WriteLine("Excellent!");
            }
        }
    }
}
