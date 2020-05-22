namespace _03_ferrari
{
    using System;

    class Startup
    {
        static void Main()
        {
            var driver = Console.ReadLine();
            var ferrari = new Ferrari(driver);

            Console.WriteLine(ferrari);
        }
    }
}
