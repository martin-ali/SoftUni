using System;
using System.Collections.Generic;
using System.Linq;

namespace _02_excel_functions
{
    class ExcelFunctions
    {
        private const string Separator = " | ";

        private const string Divider = ", ";

        static void Main()
        {
            var dataLineCount = int.Parse(Console.ReadLine()) - 1;

            var headers = Console.ReadLine().Split(Divider).ToList();
            var rows = new List<Dictionary<string, string>>();

            for (int i = 0; i < dataLineCount; i++)
            {
                var data = Console.ReadLine().Split(Divider);
                var row = new Dictionary<string, string>();

                var col = 0;
                foreach (var header in headers)
                {
                    row[header] = data[col++];
                }

                rows.Add(row);
            }

            var commandData = Console.ReadLine().Split();
            var command = commandData[0];
            var column = commandData[1];

            if (command == "hide")
            {
                headers.Remove(column);

                rows.ForEach(row => row.Remove(column));
            }
            else if (command == "sort")
            {
                rows = rows.OrderBy(row => row[column]).ToList();
            }
            else if (command == "filter")
            {
                var value = commandData[2];

                rows = rows.Where(row => row[column] == value).ToList();
            }

            Console.WriteLine(string.Join(Separator, headers));

            foreach (var row in rows)
            {
                Console.WriteLine(string.Join(Separator, row.Values));
            }
        }
    }
}
/*

4
name, age, grade
Peter, 25, 5.00
George, 34, 6.00
Marry, 28, 5.49
sort name

4
firstName, age, grade, course
Peter, 25, 5.00, C#-Advanced
George, 34, 6.00, Tech
Marry, 28, 5.49, Ruby
filter firstName Marry

*/
