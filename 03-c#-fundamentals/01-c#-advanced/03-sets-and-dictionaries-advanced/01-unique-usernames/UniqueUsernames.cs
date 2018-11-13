using System;
using System.Collections.Generic;

namespace _01_unique_usernames
{
    public class UniqueUsernames
    {
        public static void Main()
        {
            var usernameCount = int.Parse(Console.ReadLine());

            var uniqueUsernames = new HashSet<string>();
            for (int i = 0; i < usernameCount; i++)
            {
                var username = Console.ReadLine();
                uniqueUsernames.Add(username);
            }

            foreach (var username in uniqueUsernames)
            {
                Console.WriteLine(username);
            }
        }
    }
}
