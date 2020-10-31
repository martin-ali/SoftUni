using System;
using System.Data.SqlClient;
using Common;

namespace _06.RemoveVillain
{
    class Startup
    {
        static void Main()
        {
            using var connection = new SqlConnection(ConnectionStrings.MinionsDB);
            connection.Open();

            var transaction = connection.BeginTransaction();

            var villainId = int.Parse(Console.ReadLine());
            var villainName = GetVillainName(connection, transaction, villainId);

            if (villainName == null)
            {
                Console.WriteLine("No such villain was found.");
                return;
            }

            int affectedMinions = GetMinionsOfVillain(connection, transaction, villainId);

            ReleaseMinionsFromVillain(connection, transaction, villainId);

            RemoveVillain(connection, transaction, villainId);

            Console.WriteLine($"{villainName} was deleted.");
            Console.WriteLine($"{affectedMinions} minions were released.");

            transaction.Commit();
        }

        private static string GetVillainName(SqlConnection connection, SqlTransaction transaction, int villainId)
        {
            using var getVillainName = new SqlCommand("select Name from Villains where Id = @id", connection, transaction);
            getVillainName.Parameters.AddWithValue("@id", villainId);
            var villainName = (string)getVillainName.ExecuteScalar();
            return villainName;
        }

        private static void ReleaseMinionsFromVillain(SqlConnection connection, SqlTransaction transaction, int villainId)
        {
            using var releaseMinions = new SqlCommand("delete from MinionsVillains where VillainId = @id", connection, transaction);
            releaseMinions.Parameters.AddWithValue("@id", villainId);
            releaseMinions.ExecuteNonQuery();
        }

        private static int GetMinionsOfVillain(SqlConnection connection, SqlTransaction transaction, int villainId)
        {
            using var minions = new SqlCommand("select COUNT(DISTINCT(MinionId)) from MinionsVillains where VillainId = @id", connection, transaction);
            minions.Parameters.AddWithValue("@id", villainId);
            var minionsCount = (int)minions.ExecuteScalar();

            return minionsCount;
        }


        private static int RemoveVillain(SqlConnection connection, SqlTransaction transaction, int villainId)
        {
            using var removeVillain = new SqlCommand("delete from Villains where Id = @id", connection, transaction);
            removeVillain.Parameters.AddWithValue("@id", villainId);
            var affectedMinions = removeVillain.ExecuteNonQuery();
            return affectedMinions;
        }
    }
}
