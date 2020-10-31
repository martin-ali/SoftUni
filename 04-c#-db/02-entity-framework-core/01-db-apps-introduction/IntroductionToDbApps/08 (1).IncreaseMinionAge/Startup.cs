using System;
using System.Data.SqlClient;
using Common;

namespace _08.IncreaseMinionAge
{
    class Startup
    {
        static void Main()
        {
            using var connection = new SqlConnection(ConnectionStrings.MinionsDB);
            connection.Open();

            var minionIds = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
            var minionIdsRange = string.Join(", ", minionIds);

            using var increaseMinionsAge = new SqlCommand($"update Minions set Age += 1 where Id in ({minionIdsRange})", connection);
            increaseMinionsAge.ExecuteNonQuery();

            // Using RIGHT() creates issues with Minion with Id = 3, Name = "Bob", so SUBSTRING() is used instead
            using var changeMinionsNames = new SqlCommand($"update Minions set Name =  UPPER(LEFT(Name, 1)) + LOWER(SUBSTRING(Name, 2, LEN(Name))) where Id in ({minionIdsRange})", connection);
            changeMinionsNames.ExecuteNonQuery();

            using var selectMinions = new SqlCommand($"select Name, Age, TownId from Minions", connection);
            using var minions = selectMinions.ExecuteReader();

            while (minions.Read())
            {
                var name = (string)minions["Name"];
                var age = (int)minions["Age"];

                Console.WriteLine($"{name} {age}");
            }
        }
    }
}
