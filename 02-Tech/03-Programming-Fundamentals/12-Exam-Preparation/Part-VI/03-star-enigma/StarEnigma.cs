using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace _03_star_enigma
{
    class StarEnigma
    {
        static void Main()
        {
            var messageCount = int.Parse(Console.ReadLine());
            var attackedPlanets = new List<(string planetName, int population, string attackType, int soldierCount, bool isValid)>();
            var destroyedPlanets = new List<(string planetName, int population, string attackType, int soldierCount, bool isValid)>();

            for (int i = 0; i < messageCount; i++)
            {
                var encryptedMessage = Console.ReadLine();
                var decryptedInformation = DecryptStarEnigma(encryptedMessage);

                if (decryptedInformation.isValid && decryptedInformation.attackType == "A")
                {
                    attackedPlanets.Add(decryptedInformation);
                }
                else if (decryptedInformation.isValid && decryptedInformation.attackType == "D")
                {
                    destroyedPlanets.Add(decryptedInformation);
                }
            }

            var orderedAttacks = attackedPlanets.OrderBy(p => p.planetName);
            var orderedDestructions = destroyedPlanets.OrderBy(p => p.planetName);

            Console.WriteLine($"Attacked planets: {orderedAttacks.Count()}");
            foreach (var attack in orderedAttacks)
            {
                Console.WriteLine($"-> {attack.planetName}");
            }

            Console.WriteLine($"Destroyed planets: {orderedDestructions.Count()}");
            foreach (var destruction in orderedDestructions)
            {
                Console.WriteLine($"-> {destruction.planetName}");
            }
        }

        private static (string planetName, int population, string attackType, int soldierCount, bool isValid) DecryptStarEnigma(string encryptedMessage)
        {
            var keyLetters = new char[] { 's', 't', 'a', 'r' };
            var decryptionKey = encryptedMessage.Count(x => keyLetters.Contains(Char.ToLower(x)));

            var workingMessage = string.Concat(encryptedMessage.Select(x => (char)(x - decryptionKey)));
            var separator = @"[^@!:>-]*";
            var messageInformation = Regex.Match(workingMessage, $@"@([A-Za-z]+){separator}:(\d+){separator}!{separator}([AD]){separator}!{separator}->{separator}(\d+)");

            if (messageInformation.Success)
            {
                var planet = messageInformation.Groups[1].Value;
                var population = int.Parse(messageInformation.Groups[2].Value);
                var attackType = messageInformation.Groups[3].Value;
                var soldierCount = int.Parse(messageInformation.Groups[4].Value);

                return (planet, population, attackType, soldierCount, true);
            }

            return ("", 0, "", 0, false);
        }
    }
}
/*

2
STCDoghudd4=63333$D$0A53333
EHfsytsnhf?8555&I&2C9555SR

3
tt(''DGsvywgerx>6444444444%H%1B9444
GQhrr|A977777(H(TTTT
EHfsytsnhf?8555&I&2C9555SR

 */
