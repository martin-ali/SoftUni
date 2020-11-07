using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using Common;

namespace _07.PrintAllMinionNames
{
    class Startup
    {
        static void Main()
        {
            using var connection = new SqlConnection(ConnectionStrings.MinionsDB);
            connection.Open();

            var getMinionsQuery =
                "SELECT\n" +
                    "Id,\n" +
                    "Name,\n" +
                    "Age\n" +
                "FROM\n" +
                    "Minions\n";
            using var getMinions = new SqlCommand(getMinionsQuery, connection);
            using var minionsReader = getMinions.ExecuteReader();

            var minions = new List<string>();
            while (minionsReader.Read())
            {
                var name = (string)minionsReader["Name"];

                minions.Add(name);
            }

            minions = Reorder(minions);

            foreach (var minion in minions)
            {
                Console.WriteLine(minion);
            }
        }

        private static List<T> Reorder<T>(List<T> items)
        {
            var orderedItems = new T[items.Count];

            int middle = (items.Count / 2) + 1;
            var firstHalf = new Queue<T>(items.Take(middle));
            var secondHalf = new Stack<T>(items.Skip(middle));

            var current = 0;
            while (firstHalf.Any() || secondHalf.Any())
            {
                if (firstHalf.Any())
                {
                    orderedItems[current++] = firstHalf.Dequeue();
                }

                if (secondHalf.Any())
                {
                    orderedItems[current++] = secondHalf.Pop();
                }
            }

            return orderedItems.ToList();
        }
    }
}
