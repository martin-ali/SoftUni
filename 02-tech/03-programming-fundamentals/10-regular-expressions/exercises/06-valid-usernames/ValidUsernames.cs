using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace _06_valid_usernames
{
    class ValidUsernames
    {
        static void Main()
        {
            var validUsernamePattern = new Regex(@"^[A-Za-z]\w{2,24}$");
            var input = Console.ReadLine();

            var validUsernames = Regex
                                    .Split(input, @"[ \\/()]+")
                                    .Where(n => validUsernamePattern.IsMatch(n))
                                    .ToArray();

            var firstUsername = string.Empty;
            var secondUsername = string.Empty;
            for (int i = 1; i < validUsernames.Length; i++)
            {
                var previous = validUsernames[i - 1];
                var current = validUsernames[i];

                if ((previous.Length + current.Length) > (firstUsername.Length + secondUsername.Length))
                {
                    firstUsername = previous;
                    secondUsername = current;
                }
            }

            Console.WriteLine(firstUsername);
            Console.WriteLine(secondUsername);
        }
    }
}

/*

ds3bhj y1ter/wfsdg 1nh_jgf ds2c_vbg\4htref

min23/ace hahah21 ( sasa ) att3454/a/a2/abc

chico/ gosho \ sapunerka (3sas) mazut lelQ_Van4e

 */
