namespace _04_telephony
{
    using System;

    class Startup
    {
        static void Main()
        {
            var numbers = Console.ReadLine().Split(' ');
            var sites = Console.ReadLine().Split(' ');
            var smartphone = new Smartphone();

            foreach (var number in numbers)
            {
                try
                {
                    Console.WriteLine(smartphone.Call(number));
                }
                catch (ArgumentException exception)
                {
                    Console.WriteLine(exception.Message);
                }
            }

            foreach (var site in sites)
            {
                try
                {
                    Console.WriteLine(smartphone.Browse(site));
                }
                catch (ArgumentException exception)
                {
                    Console.WriteLine(exception.Message);
                }
            }
        }
    }
}
