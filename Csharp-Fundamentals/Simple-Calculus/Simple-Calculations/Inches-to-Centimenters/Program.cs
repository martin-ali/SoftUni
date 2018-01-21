using System;

namespace Inches_to_Centimenters
{
    class Program
    {
        static void Main()
        {
            Console.Write("inches = ");

            var inches = double.Parse(Console.ReadLine());
            var centimeters = inches * 2.54;

            Console.Write("Centimeters = ");
            Console.WriteLine(centimeters);
        }
    }
}
