using Common;
using System;
using System.Data.SqlClient;

namespace _03.MinionNames
{
    class Startup
    {
        static void Main()
        {
            using var connection = new SqlConnection(ConnectionStrings.MinionsDB);
            connection.Open();
            var villainId = int.Parse(Console.ReadLine());

            // Get villain
            var selectVillainQuery = $"select Name from Villains where Id = {villainId}";
            using var selectVillain = new SqlCommand(selectVillainQuery, connection);

            var villainName = selectVillain.ExecuteScalar();
            if (villainName == null)
            {
                Console.WriteLine($"No villain with ID {villainId} exists in the database.");
                return;
            }
            else
            {
                Console.WriteLine($"Villain: {villainName}");
            }

            // Get minions
            var selectMinionsQuery =
                    "SELECT\n" +
                        "m.Name,\n" +
                        "m.Age\n" +
                    "FROM\n" +
                        "MinionsVillains mv\n" +
                        "JOIN Minions m ON m.Id = mv.MinionId\n" +
                    $"WHERE mv.VillainId = {villainId}\n" +
                    "ORDER BY m.Name ASC\n";
            using var selectMinions = new SqlCommand(selectMinionsQuery, connection);
            using var minions = selectMinions.ExecuteReader();

            var index = 1;
            while (minions.Read())
            {
                var minionName = (string)minions["Name"];
                var minionAge = (int)minions["Age"];
                Console.WriteLine($"{index++}. {minionName} {minionAge}");
            }
        }
    }
}