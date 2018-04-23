using System;

namespace _01_debit_card_number
{
    class DebitCardNumber
    {
        static void Main()
        {
            for (int i = 0; i < 4; i++)
            {
                var number = Console.ReadLine();
                Console.Write($"{number.PadLeft(4, '0')} ");
            }
        }
    }
}
