using System;

namespace _05_compare_char_arrays
{
    class CompareCharArrays
    {
        static void Main()
        {
            var firstArray = Console.ReadLine().Split(' ');
            var secondArray = Console.ReadLine().Split(' ');

            var secondIsSmaller = false;
            var end = Math.Min(firstArray.Length, secondArray.Length);
            for (int i = 0; i < end; i++)
            {
                var comparisonResult = firstArray[i].CompareTo(secondArray[i]);
                if (comparisonResult <= -1)
                {
                    secondIsSmaller = false;
                    break;
                }
                else if (comparisonResult >= 1)
                {
                    secondIsSmaller = true;
                    break;
                }
            }


            if (secondIsSmaller)
            {
                Console.WriteLine(String.Join("", secondArray));
                Console.WriteLine(String.Join("", firstArray));
            }
            else
            {
                Console.WriteLine(String.Join("", firstArray));
                Console.WriteLine(String.Join("", secondArray));
            }
        }
    }
}
/*

a b c
d e f

p e t er
a n n i e

a n n i e
a n n

a b
a b

 */
