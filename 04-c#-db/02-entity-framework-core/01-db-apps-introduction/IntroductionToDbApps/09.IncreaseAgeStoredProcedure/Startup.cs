using System;
using System.Data.SqlClient;
using Common;

namespace _09.IncreaseAgeStoredProcedure
{
    class Startup
    {
        static void Main()
        {
            using var connection = new SqlConnection(ConnectionStrings.MinionsDB);
            connection.Open();

            var procedure =
                "CREATE OR ALTER PROCEDURE usp_GetOlder(@minionId INT)\n" +
                "AS\n" +
                "UPDATE Minions\n" +
                "SET Age += 1\n" +
                "WHERE Id = @minionId\n";
            using var createProcedure = new SqlCommand(procedure, connection);
            createProcedure.ExecuteNonQuery();

            var minionId = int.Parse(Console.ReadLine());

            using var executeProcedure = new SqlCommand("execute dbo.usp_GetOlder @id", connection);
            executeProcedure.Parameters.AddWithValue("@id", minionId);
            executeProcedure.ExecuteNonQuery();

            using var selectMinion = new SqlCommand("select Name, Age from Minions where Id = @id", connection);
            selectMinion.Parameters.AddWithValue("@id", minionId);

            using var minion = selectMinion.ExecuteReader();
            while (minion.Read())
            {
                var name = (string)minion["Name"];
                var age = (int)minion["Age"];

                Console.WriteLine($"{name} - {age} years old");
            }
        }
    }
}
