using System;

namespace control_number
{
    class Program
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            int m = int.Parse(Console.ReadLine());
            int controlNumber = int.Parse(Console.ReadLine());

            int counter = 0;
            var sum = 0;
            for (int i = 1; i <= n; i++)
            {
                for (int j = m; j >= 1; j--)
                {
                    counter++;
                    sum += (i * 2);
                    sum += (j * 3);
                    if (sum >= controlNumber)
                    {
                        i = n + 1;
                        break;
                    }
                }
            }

            if (sum >= controlNumber)
            {
                Console.WriteLine($"{counter} moves");
                Console.WriteLine($"Score: {sum} >= {controlNumber}");
            }
            else
            {
                Console.WriteLine($"{counter} moves");
            }
        }
    }
}
