using System;

namespace _05_date_modifier
{
    public class DateModifier
    {
        public int GetDifferenceInDays(string firstDateString, string secondDateString)
        {
            var firstDate = DateTime.Parse(firstDateString);
            var secondDate = DateTime.Parse(secondDateString);

            var differenceInTicks = firstDate.Ticks - secondDate.Ticks;
            var differenceInDays = TimeSpan.FromTicks(differenceInTicks).Days;

            return Math.Abs(differenceInDays);
        }
    }
}