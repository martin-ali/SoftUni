using System;

namespace Speed_Information
{
    class Program
    {
        static void Main()
        {
            var currentSpeed = double.Parse(Console.ReadLine());

            if (currentSpeed <= 10)
            {
                Console.WriteLine("slow");
            }
            else if (currentSpeed > 10 && currentSpeed <= 50)
            {
                Console.WriteLine("average");
            }
            else if (currentSpeed > 50 && currentSpeed <= 150)
            {
                Console.WriteLine("fast");
            }
            else if (currentSpeed > 150 && currentSpeed <= 1000)
            {
                Console.WriteLine("ultra fast");
            }
            else
            {
                Console.WriteLine("extremely fast");
            }
        }
    }
}
