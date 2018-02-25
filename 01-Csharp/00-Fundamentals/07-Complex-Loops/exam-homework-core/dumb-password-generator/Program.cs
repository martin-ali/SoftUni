using System;

namespace dumb_password_generator
{
    class Program
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            int l = int.Parse(Console.ReadLine());

            for (int firstNumber = 1; firstNumber < n; firstNumber++)
            {
                for (int secondNumber = 1; secondNumber < n; secondNumber++)
                {
                    for (int firstLetter = 'a'; firstLetter < n + 'a'; firstLetter++)
                    {
                        for (int secondLetter = 'a'; secondLetter < n + 'a'; secondLetter++)
                        {
                            for (int thirdNumber = Math.Max(firstNumber, secondNumber); thirdNumber < n; thirdNumber++)
                            {
                                Console.Write($"{firstNumber}{secondNumber}{firstLetter}{secondLetter}{thirdNumber} ");
                            }
                        }
                    }
                }
            }
        }
    }
}
