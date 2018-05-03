using System;
using System.Linq;

namespace _02_rotate_and_sum
{
    class RotateAndSum
    {
        static void Main()
        {
            var arr = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            var numberOfRotations = int.Parse(Console.ReadLine());

            var sumArray = new int[arr.Length];
            for (int i = 0; i < numberOfRotations; i++)
            {
                arr = Rotate(arr);
                sumArray = SequenceSum(sumArray, arr);
            }

            Console.WriteLine(String.Join(" ", sumArray));
        }

        private static int[] SequenceSum(int[] firstArray, int[] secondArray)
        {
            var sumArr = new int[firstArray.Length];
            for (int index = 0; index < firstArray.Length; index++)
            {
                sumArr[index] = firstArray[index] + secondArray[index];
            }

            return sumArr;
        }

        private static int[] Rotate(int[] arr)
        {
            var rotatedArr = new int[arr.Length];
            rotatedArr[0] = arr[arr.Length - 1];
            for (int i = arr.Length - 1; i > 0; i--)
            {
                rotatedArr[i] = arr[i - 1];
            }

            return rotatedArr;
        }
    }
}
/*
1 2 3 4 5

3 2 4 -1
2
 */
