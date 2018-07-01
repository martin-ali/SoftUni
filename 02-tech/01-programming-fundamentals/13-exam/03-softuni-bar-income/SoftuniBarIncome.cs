using System;
using System.Text.RegularExpressions;

namespace _03_softuni_bar_income
{
    class SoftuniBarIncome
    {
        // %([A-Z][a-z]+)%.*<(\w+)>.*\|(\d+)\|\D*(\d+(\.\d+)?)\$
        static void Main()
        {
            var namePattern = @"%([A-Z][a-z]+)%";
            var productPattern = @"<(\w+)>";
            var countPattern = @"\|(\d+)\|";
            var pricePattern = @"(\d+(\.\d+)?)\$";
            var validOrderRegex = new Regex($@"{namePattern}.*{productPattern}.*{countPattern}\D*{pricePattern}");
            var totalIncome = 0M;

            string input = null;
            while ((input = Console.ReadLine()) != "end of shift")
            {
                var orderMatch = validOrderRegex.Match(input);
                if (orderMatch.Success)
                {
                    var customer = orderMatch.Groups[1].Value;
                    var product = orderMatch.Groups[2].Value;
                    var count = int.Parse(orderMatch.Groups[3].Value);
                    var price = decimal.Parse(orderMatch.Groups[4].Value);

                    var bill = price * count;
                    Console.WriteLine($"{customer}: {product} - {bill:0.00}");

                    totalIncome += bill;
                }
            }

            Console.WriteLine($"Total income: {totalIncome:0.00}");
        }
    }
}
/*

%George%<Croissant>|2|10.3$
%Peter%<Gum>|1|1.3$
%Maria%<Cola>|1|2.4$
end of shift

%InvalidName%<Croissant>|2|10.3$
%Peter%<Gum>1.3$
%Maria%<Cola>|1|2.4
%Valid%<Valid>valid|10|valid20$
end of shift

 */
