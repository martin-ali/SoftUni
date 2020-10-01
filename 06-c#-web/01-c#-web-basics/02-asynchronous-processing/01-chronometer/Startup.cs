namespace _01_chronometer
{
    using System;

    class Startup
    {
        static void Main()
        {
            // var chronometer = new Chronometer();
            // chronometer.Start();

            // Thread.Sleep(1562);

            // Console.WriteLine(chronometer.Lap());

            // chronometer.Stop();

            var chronometer = new Chronometer();

            while (true)
            {
                var command = Console.ReadLine();

                switch (command)
                {
                    case "start":
                        chronometer.Start();
                        break;
                    case "stop":
                        chronometer.Stop();
                        break;
                    case "lap":
                        var lap = chronometer.Lap();
                        Console.WriteLine(lap);
                        break;
                    case "laps":
                        // Not part of chronometer functionality as it would break the single responsibility principle
                        for (int current = 0; current < chronometer.Laps.Count; current++)
                        {
                            var index = current + 1;
                            Console.WriteLine($"{index}. {chronometer.Laps[current]}");
                        }
                        break;
                    case "time":
                        var time = chronometer.GetTime;
                        Console.WriteLine(time);
                        break;
                    case "reset":
                        chronometer.Reset();
                        break;
                    case "exit":
                        Environment.Exit(0);
                        break;
                }
            }
        }
    }
}
