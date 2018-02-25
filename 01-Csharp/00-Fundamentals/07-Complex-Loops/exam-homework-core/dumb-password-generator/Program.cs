using System;

namespace dumb_password_generator
{
    class Program
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            int l = int.Parse(Console.ReadLine());

            for (int firstNumber = 1; firstNumber <= n; firstNumber++)
            {
                for (int secondNumber = 1; secondNumber <= n; secondNumber++)
                {
                    for (int firstLetter = 'a'; firstLetter < 'a' + l; firstLetter++)
                    {
                        for (int secondLetter = 'a'; secondLetter < 'a' + l; secondLetter++)
                        {
                            for (int thirdNumber = Math.Max(firstNumber, secondNumber) + 1; thirdNumber <= n; thirdNumber++)
                            {
                                Console.Write($"{firstNumber}{secondNumber}{(char)firstLetter}{(char)secondLetter}{thirdNumber} ");
                            }
                        }
                    }
                }
            }
        }
    }
}
