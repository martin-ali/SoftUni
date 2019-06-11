using System;
using System.Linq;

namespace _06_reverse_and_exclude
{
    class ReverseAndExclude
    {
        static void Main()
        {
            Func<int, Func<int, bool>> isNotDivisibleBy = divisor => (dividend => dividend % divisor != 0);

            var numbers = Console.ReadLine().Split().Select(int.Parse);
            var numberToDivideBy = int.Parse(Console.ReadLine());

            var divisibleNumbers = numbers
                                    .Where(isNotDivisibleBy(numberToDivideBy))
                                    .Reverse();

            Console.WriteLine(string.Join(' ', divisibleNumbers));
        }
    }
}
