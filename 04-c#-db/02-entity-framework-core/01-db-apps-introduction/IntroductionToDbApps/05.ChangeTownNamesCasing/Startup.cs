using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using Common;

namespace _05.ChangeTownNamesCasing
{
    class Startup
    {
        private const string TowsAffectedMessage = "{0} town names were affected.";

        private const string NoTownsAffectedMessage = "No town names were affected.";

        static void Main()
        {
            using var connection = new SqlConnection(ConnectionStrings.MinionsDB);
            connection.Open();

            var countryName = Console.ReadLine();

            var countryId = GetCountryIdFromName(connection, countryName);

            // Could use try/catch as well
            if (countryId == null)
            {
                Console.WriteLine(NoTownsAffectedMessage);
                return;
            }

            var affectedRows = ChangeTownsCasing(connection, (int)countryId);

            if (affectedRows == 0)
            {
                Console.WriteLine(NoTownsAffectedMessage);
                return;
            }

            List<string> townsAffected = GetAffectedTowns(connection, (int)countryId);

            Console.WriteLine(string.Format(TowsAffectedMessage, affectedRows));
            Console.WriteLine($"[{string.Join(", ", townsAffected)}]");
        }

        private static int ChangeTownsCasing(SqlConnection connection, int countryId)
        {
            var changeTownsCasingQuery = "UPDATE Towns SET Name = UPPER(Name) WHERE CountryCode = @id";
            using var changeTownsCasing = new SqlCommand(changeTownsCasingQuery, connection);
            changeTownsCasing.Parameters.AddWithValue("@id", countryId);

            var affectedRows = changeTownsCasing.ExecuteNonQuery();
            return affectedRows;
        }

        private static int? GetCountryIdFromName(SqlConnection connection, string countryName)
        {
            var getCountryIdQuery = "select Id from Countries where Name = @name";
            using var getCountryId = new SqlCommand(getCountryIdQuery, connection);
            getCountryId.Parameters.AddWithValue("@name", countryName);

            var countryId = (int?)getCountryId.ExecuteScalar();
            return countryId;
        }

        private static List<string> GetAffectedTowns(SqlConnection connection, int countryId)
        {
            var townsAffected = new List<string>();

            var selectTownsQuery = "select Name from Towns where CountryCode = @id";
            using var selectTowns = new SqlCommand(selectTownsQuery, connection);
            selectTowns.Parameters.AddWithValue("@id", countryId);
            var towns = selectTowns.ExecuteReader();

            using (towns)
            {
                while (towns.Read())
                {
                    townsAffected.Add((string)towns["Name"]);
                }
            }

            return townsAffected;
        }
    }
}
