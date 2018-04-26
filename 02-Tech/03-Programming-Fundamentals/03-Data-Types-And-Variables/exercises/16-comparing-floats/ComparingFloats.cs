using System;

namespace _16_comparing_floats
{
    class ComparingFloats
    {
        static void Main()
        {
            double a = double.Parse(Console.ReadLine());
            double b = double.Parse(Console.ReadLine());

            double errorRange = 0.000001;
            var areNumbersIdentical = Math.Abs(a - b) <= errorRange;
            Console.WriteLine(areNumbersIdentical);
        }
    }
}
