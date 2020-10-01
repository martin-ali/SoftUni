namespace _01_chronometer
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;

    public class Chronometer : IChronometer
    {
        private Stopwatch stopwatch;

        public Chronometer()
        {
            this.stopwatch = new Stopwatch();
            this.Laps = new List<string>();
        }

        public string GetTime => this.formatTimeSpan(this.stopwatch.Elapsed);

        public List<string> Laps { get; private set; }

        private string formatTimeSpan(TimeSpan span)
        {
            var formattedTime = $"{span.Minutes:00}:{span.Seconds:00}:{span.Milliseconds:0000}";

            return formattedTime;
        }

        public string Lap()
        {
            var lapSpan = this.stopwatch.Elapsed;

            var lap = this.formatTimeSpan(lapSpan);
            if (this.stopwatch.IsRunning)
            {
                this.Laps.Add(lap);
            }

            return lap;
        }

        public void Reset()
        {
            this.stopwatch.Reset();
            this.Laps.Clear();
        }

        public void Start()
        {
            this.stopwatch.Start();
        }

        public void Stop()
        {
            this.stopwatch.Stop();
        }
    }
}