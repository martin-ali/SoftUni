using Common;
using System;
using System.Data.SqlClient;

namespace _04.AddMinion
{
    class Startup
    {
        private const int VillainDefaultEvilnessFactorId = 4;

        static void Main()
        {
            // Get input
            var minionData = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
            var villainName = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries)[1];
            var minionName = minionData[1];
            var minionAge = int.Parse(minionData[2]);
            var townName = minionData[3];

            // Open connection
            using var connection = new SqlConnection(ConnectionStrings.MinionsDB);
            connection.Open();

            using var transaction = connection.BeginTransaction();

            try
            {
                var townReport = EnsureTownExists(townName, connection, transaction);
                if (townReport != null)
                {
                    Console.WriteLine(townReport);
                }

                var villainReport = EnsureVillainExists(villainName, connection, transaction);
                if (villainReport != null)
                {
                    Console.WriteLine(villainReport);
                }

                EnsureMinionExists(minionName, minionAge, townName, connection, transaction);

                AssignMinionToVillain(villainName, minionName, connection, transaction);

                transaction.Commit();
            }
            catch (System.Exception)
            {
                transaction.Rollback();
            }
        }

        private static string EnsureTownExists(string townName, SqlConnection connection, SqlTransaction transaction)
        {
            using var selectTown = new SqlCommand("select Id from Towns where Name = @name", connection, transaction);
            selectTown.Parameters.AddWithValue("@name", townName);

            var townExists = selectTown.ExecuteScalar() != null;

            if (townExists == false)
            {
                using var insertTown = new SqlCommand($"insert into Towns(Name) values(@name)", connection, transaction);
                insertTown.Parameters.AddWithValue("@name", townName);
                insertTown.ExecuteNonQuery();
                return $"Town {townName} was added to the database.";
            }

            return null;
        }

        private static string EnsureVillainExists(string villainName, SqlConnection connection, SqlTransaction transaction)
        {
            using var selectVillain = new SqlCommand($"select Id from Villains where Name = @name", connection, transaction);
            selectVillain.Parameters.AddWithValue("@name", villainName);

            var villainExists = selectVillain.ExecuteScalar() != null;

            if (villainExists == false)
            {
                using var insertVillain = new SqlCommand($"insert into Villains(Name, EvilnessFactorId) values(@name, @evilnessFactorId)", connection, transaction);
                insertVillain.Parameters.AddWithValue("@name", villainName);
                insertVillain.Parameters.AddWithValue("@evilnessFactorId", VillainDefaultEvilnessFactorId);
                insertVillain.ExecuteNonQuery();
                return $"Villain {villainName} was added to the database.";
            }

            return null;
        }

        private static void EnsureMinionExists(string minionName, int minionAge, string townName, SqlConnection connection, SqlTransaction transaction)
        {
            using var selectMinion = new SqlCommand($"select Id from Minions where Name = @name", connection, transaction);
            selectMinion.Parameters.AddWithValue("@name", minionName);

            var minionExists = selectMinion.ExecuteScalar() != null;

            if (minionExists == false)
            {
                using var selectTownId = new SqlCommand($"select Id from Towns where Name = @name", connection, transaction);
                selectTownId.Parameters.AddWithValue("@name", townName);
                var townId = (int)selectTownId.ExecuteScalar();

                using var insertMinion = new SqlCommand($"insert into Minions(Name, Age, TownId) values(@name, @age, @townId)", connection, transaction);
                insertMinion.Parameters.AddWithValue("@name", minionName);
                insertMinion.Parameters.AddWithValue("@age", minionAge);
                insertMinion.Parameters.AddWithValue("@townId", townId);
                insertMinion.ExecuteNonQuery();
            }
        }

        private static void AssignMinionToVillain(string villainName, string minionName, SqlConnection connection, SqlTransaction transaction)
        {
            using var selectVillainId = new SqlCommand($"select Id from Villains where Name = @name", connection, transaction);
            selectVillainId.Parameters.AddWithValue("@name", villainName);

            var villainId = (int)selectVillainId.ExecuteScalar();

            using var selectMinionId = new SqlCommand($"select Id from Minions where Name = @name", connection, transaction);
            selectMinionId.Parameters.AddWithValue("@name", minionName);

            var minionId = (int)selectMinionId.ExecuteScalar();

            using var insertMinionsVillainsRelation = new SqlCommand($"insert into MinionsVillains(MinionId, VillainId) values(@minionId, @villainId)", connection, transaction);
            insertMinionsVillainsRelation.Parameters.AddWithValue("@minionId", minionId);
            insertMinionsVillainsRelation.Parameters.AddWithValue("@villainId", villainId);
            insertMinionsVillainsRelation.ExecuteNonQuery();

            Console.WriteLine($"Successfully added {minionName} to be minion of {villainName}.");
        }
    }
}
/*

Minion: Bob 14 Berlin
Villain: Gru

Minion: Cathleen 20 Liverpool
Villain: Gru

Minion: Mars 23 Sofia
Villain: Poppy

Minion: Carry 20 Eindhoven
Villain: Jimmy

Minion: ThisWorks 20 WorksWell
Villain: DefinitelyWorks

Minion: ThisWorks2 20 WorksWell2
Villain: DefinitelyWorks2
*/
