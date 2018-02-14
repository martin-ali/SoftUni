using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Christmas_Tree
{
    class Program
    {
        static void Main()
        {
            var size = int.Parse(Console.ReadLine());

            for (int current = 1; current <= size; current++)
            {
                Console.WriteLine(DrawLineWithIntervalsAndPadding("*", "|", current, size - current));
            }

            for (int current = size - 1; current > 0; current--)
            {
            }
        }

        static string DrawLineWithIntervalsAndPadding(string leaves, string trunk, int size, int length)
        {
            var x = "";
            var rowToWithIntervals = String.Join(" ", x.ToCharArray());
            return rowToWithIntervals;
        }
    }
}
