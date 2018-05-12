using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;

namespace _05_parking_validation
{
    class ParkingValidation
    {

        private static string licensePlatePattern = @"^[A-Z]{2}\d{4}[A-Z]{2}$";

        static void Main()
        {

            #if DEBUG
            var testNumber = Console.ReadLine();
            Console.SetIn(new StreamReader($"tests/test{testNumber}.txt"));
            #endif

            var licensePlatesByUser = new Dictionary<string, string>();
            var usedLicensePlates = new HashSet<string>();
            var numberOfLines = int.Parse(Console.ReadLine());

            for (int i = 0; i < numberOfLines; i++)
            {
                var input = Console.ReadLine().Split(' ');

                if (input[0] == "register")
                {
                    var user = input[1];
                    var licensePlate = input[2];

                    if (licensePlatesByUser.ContainsKey(user))
                    {
                        Console.WriteLine($"ERROR: already registered with plate number {licensePlatesByUser[user]}");
                        continue;
                    }
                    else if (!IsValidLicensePlate(licensePlate))
                    {
                        Console.WriteLine($"ERROR: invalid license plate {licensePlate}");
                        continue;
                    }
                    else if (usedLicensePlates.Contains(licensePlate))
                    {
                        Console.WriteLine($"ERROR: license plate {licensePlate} is busy");
                        continue;
                    }

                    usedLicensePlates.Add(licensePlate);
                    licensePlatesByUser[user] = licensePlate;
                    Console.WriteLine($"{user} registered {licensePlate} successfully");
                }
                else
                {
                    var user = input[1];
                    if (licensePlatesByUser.ContainsKey(user))
                    {
                        var licensePlate = licensePlatesByUser[user];
                        usedLicensePlates.Remove(licensePlate);
                        licensePlatesByUser.Remove(user);
                        Console.WriteLine($"user {user} unregistered successfully");
                    }
                    else
                    {
                        Console.WriteLine($"ERROR: user {user} not found");
                    }
                }
            }

            foreach (var user in licensePlatesByUser)
            {
                Console.WriteLine($"{user.Key} => {user.Value}");
            }
        }

        private static bool IsValidLicensePlate(string licensePlate)
        {
            return Regex.IsMatch(licensePlate, licensePlatePattern) && licensePlate.Length == 8;
        }
    }
}
