﻿using System;
using System.Collections.Generic;

namespace _13_number_pyramid
{
    class Program
    {
        static void Main()
        {
            var num = int.Parse(Console.ReadLine());

            for (int currentRowNumber = 1, currentNumber = 1; currentNumber <= num; currentRowNumber++)
            {
                for (int currentCol = 1; currentCol <= currentRowNumber && currentNumber <= num; currentCol++)
                {
                    Console.Write($"{currentNumber++} ");
                }

                Console.WriteLine();
            }
        }
    }
}
