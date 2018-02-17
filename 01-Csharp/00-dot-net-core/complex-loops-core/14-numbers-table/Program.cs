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
                for (int col = 0, decider = 0; col < size; col++)
                {
                    var x=0;
                    var y=true;

                    if (currentNumber + col <= size)
                    {
                        y=false;
                    }

                    if(y)
                    {
                        x = currentNumber+decider;
                        decider++;
                    }
                    else
                    {
                        x = currentNumber+decider;
                        decider--;
                    }    
                    
                    currentRow[col] = x;
                }

                currentNumber++;
                Console.WriteLine(String.Join(" ", currentRow));
            }
        }
    }
}
