using System;

namespace _14_numbers_table
{
    class Program
    {
        static void Main()
        {
            var size = int.Parse(Console.ReadLine());
            int currentNumber = 1;

            for (int row = 0; row < size; row++)
            {
                var currentRow = new int[size];
                bool numbersShouldKeepIncreasing = true;
                for (int col = 0, currentCol = 0, diff = 1; col < size; col++)
                {
                    var valueOfCol = currentNumber + currentCol;

                    if (valueOfCol >= size || numbersShouldKeepIncreasing == false)
                    {
                        diff = -1;
                        numbersShouldKeepIncreasing = false;
                    }

                    currentCol += diff;
                    
                    currentRow[col] = valueOfCol;
                }

                currentNumber++;
                Console.WriteLine(String.Join(" ", currentRow));
            }
        }
    }
}
