using System;

namespace Area_of_Figures
{
    class Program
    {
        static void Main()
        {
            var figureType = Console.ReadLine();
            var result = 0d;

            if (figureType == "square")
            {
                var side = double.Parse(Console.ReadLine());

                result = side * side;
            }
            else if (figureType == "rectangle")
            {
                var sideA = double.Parse(Console.ReadLine());
                var sideB = double.Parse(Console.ReadLine());

                result = sideA * sideB;
            }
            else if (figureType == "circle")
            {
                var radius = double.Parse(Console.ReadLine());

                result = Math.PI * radius * radius;
            }
            else if (figureType == "triangle")
            {
                var side = double.Parse(Console.ReadLine());
                var height = double.Parse(Console.ReadLine());

                result = side * height / 2;
            }

            Console.WriteLine(Math.Round(result, 3));
        }

    }
}

