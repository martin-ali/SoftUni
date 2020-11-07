using Common;
using System;
using System.Data.SqlClient;

namespace _02.VillainNames
{
    class Startup
    {
        static void Main()
        {
            using var connection = new SqlConnection(ConnectionStrings.MinionsDB);
            connection.Open();

            var query =
                "SELECT\n" +
                    "v.Name,\n" +
                    "COUNT(mv.MinionId) AS MinionsCount\n" +
                "FROM\n" +
                    "Villains v\n" +
                    "JOIN MinionsVillains mv ON mv.VillainId = v.Id\n" +
                "GROUP BY v.Name\n" +
                "HAVING COUNT(mv.MinionId) > 3\n" +
                "ORDER BY COUNT(mv.MinionId) DESC";

            using var command = new SqlCommand(query, connection);
            var reader = command.ExecuteReader();

            using (reader)
            {
                while (reader.Read())
                {
                    var name = (string)reader["Name"];
                    var minionsCount = (int)reader["MinionsCount"];

                    Console.WriteLine($"{name} - {minionsCount}");
                }
            }
        }
    }
}
