using System;

namespace Sum_Seconds
{
    class Program
    {
        static void Main()
        {
            //var firstRunner = 14d;
            //var secondRunner = 12d;
            //var thirdRunner = 10d;

            var firstRunner = double.Parse(Console.ReadLine());
            var secondRunner = double.Parse(Console.ReadLine());
            var thirdRunner = double.Parse(Console.ReadLine());

            double totalNumberOfSeconds = firstRunner + secondRunner + thirdRunner;

            double numberOfMinutes = Math.Truncate(totalNumberOfSeconds / 60);
            double leftOverSeconds = totalNumberOfSeconds - (numberOfMinutes * 60);

            Console.WriteLine($"{numberOfMinutes}:{leftOverSeconds.ToString().PadLeft(2, '0')}");           
        }
    }
}
