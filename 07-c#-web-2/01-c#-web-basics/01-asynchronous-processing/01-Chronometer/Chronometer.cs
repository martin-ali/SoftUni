namespace _01_Chronometer
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;

    public class Chronometer : IChronometer
    {
        public Chronometer()
        {
            this.Laps = new List<string>();
            this.stopwatch = new Stopwatch();
        }

        private Stopwatch stopwatch { get; }

        public string GetTime { get => this.GetFormattedTime(); }

        public IList<string> Laps { get; }

        private string GetFormattedTime()
        {
            var elapsedMilliseconds = (double)this.stopwatch.ElapsedMilliseconds;

            var minutes = Math.Floor(elapsedMilliseconds / 1000 / 60);
            elapsedMilliseconds -= minutes * 60 * 1000;

            var seconds = Math.Floor(elapsedMilliseconds / 1000);
            elapsedMilliseconds -= seconds * 1000;

            var milliseconds = elapsedMilliseconds;
            var time = $"{minutes:00}:{seconds:00}:{milliseconds:0000}";

            return time;
        }

        public void Start()
        {
            this.stopwatch.Start();
        }

        public void Stop()
        {
            this.stopwatch.Stop();
        }

        // Bug: Will create a lap even with a stopped chronometer
        public string Lap()
        {
            string lap = GetFormattedTime();

            this.Laps.Add(lap);

            return lap;
        }

        public void Reset()
        {
            this.stopwatch.Reset();
            this.Laps.Clear();
        }
    }
}
