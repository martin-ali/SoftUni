using System;

namespace _05_date_modifier
{
    class StartUp
    {
        static void Main()
        {
            var firstDate = Console.ReadLine();
            var secondDate = Console.ReadLine();

            var dateModifier = new DateModifier();
            var differenceInDays = dateModifier.GetDifferenceInDays(firstDate, secondDate);

            Console.WriteLine(differenceInDays);
        }
    }
}
