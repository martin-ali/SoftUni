using System;

namespace Sleepycat_Tom
{
    class Program
    {
        static void Main()
        {
            int numberOfOffDays = int.Parse(Console.ReadLine());
            int numberOfWorkdays = 365 - numberOfOffDays;

            int hoursOfPlay = (numberOfOffDays * 127) + (numberOfWorkdays * 63);
            int normalPlaytime = 30000;

            int deltaFromNorm = Math.Abs(hoursOfPlay - normalPlaytime);
            int hoursDelta = deltaFromNorm / 60;
            int minutesDelta = deltaFromNorm - (hoursDelta * 60);

            if (hoursOfPlay > normalPlaytime)
            {
                Console.WriteLine("Tom will run away");
                Console.WriteLine($"{hoursDelta} hours and {minutesDelta} minutes more for play");
            }
            else if (hoursOfPlay < normalPlaytime)
            {
                Console.WriteLine("Tom sleeps well");
                Console.WriteLine($"{hoursDelta} hours and {minutesDelta} minutes less for play");
            }
        }
    }
}
