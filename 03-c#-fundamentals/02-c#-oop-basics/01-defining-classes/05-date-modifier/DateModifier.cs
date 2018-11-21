using System;
using System.Globalization;

namespace DefiningClasses
{
    public class DateModifier
    {
        private int daysDifference;

        public DateModifier(string firstDate, string secondDate)
        {
            var firstDatex = DateTime.ParseExact(firstDate, "yyyy MM d", CultureInfo.InvariantCulture);
            var secondDatex = DateTime.ParseExact(secondDate, "yyyy MM d", CultureInfo.InvariantCulture);

            var span = TimeSpan.FromTicks(firstDatex.Ticks - secondDatex.Ticks);

            this.DaysDifference = Math.Abs(span.Days);
        }

        public int DaysDifference
        {
            get { return this.daysDifference; }
            private set { this.daysDifference = value; }
        }
    }
}