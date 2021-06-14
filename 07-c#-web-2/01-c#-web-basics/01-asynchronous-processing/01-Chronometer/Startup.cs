using System;

namespace _01_Chronometer
{
    class Startup
    {
        static void Main()
        {
            var chronometer = new Chronometer();

            while (true)
            {
                var command = Console.ReadLine().Trim();

                if (command == "start")
                {
                    chronometer.Start();
                }
                else if (command == "stop")
                {
                    chronometer.Stop();
                }
                else if (command == "lap")
                {
                    var lap = chronometer.Lap();
                    Console.WriteLine(lap);
                }
                else if (command == "laps")
                {
                    if (chronometer.Laps.Count == 0)
                    {
                        Console.WriteLine("Laps: No laps");
                        continue;
                    }

                    Console.WriteLine("Laps:");

                    var i = 0;
                    foreach (var lap in chronometer.Laps)
                    {
                        var formattedLap = $"{i++}. {lap}";
                        Console.WriteLine(formattedLap);
                    }
                }
                else if (command == "time")
                {
                    var time = chronometer.GetTime;
                    Console.WriteLine(time);
                }
                else if (command == "reset")
                {
                    chronometer.Reset();
                }
                else if (command == "exit")
                {
                    Environment.Exit(0);
                }
            }
        }
    }
}
