using System;

namespace _01_softuni_reception
{
    class SoftuniReception
    {
        static void Main()
        {
            var firstEmployee = int.Parse(Console.ReadLine());
            var secondEmployee = int.Parse(Console.ReadLine());
            var thirdEmployee = int.Parse(Console.ReadLine());
            var studentCount = double.Parse(Console.ReadLine());

            var hoursNeeded = 0;
            while (studentCount > 0)
            {
                hoursNeeded++;
                if (hoursNeeded % 4 != 0)
                {
                    studentCount -= (firstEmployee + secondEmployee + thirdEmployee);
                }
            }

            Console.WriteLine($"Time needed: {hoursNeeded}h.");
        }
    }
}
/*

5
6
4
20

1
2
3
45

2
3
5
40

 */
