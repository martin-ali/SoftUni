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
                bool numbersShouldKeepIncresing = true;
                for (int col = 0, num = 0; col < size; col++)
                {
                    var valueOfCol = currentNumber + num;

                    if (valueOfCol >= size || numbersShouldKeepIncresing == false)
                    {
                        numbersShouldKeepIncresing = false;
                        num--;
                    }
                    else
                    {
                        num++;
                    }
                    
                    currentRow[col] = valueOfCol;
                }

                currentNumber++;
                Console.WriteLine(String.Join(" ", currentRow));
            }
        }
    }
}
