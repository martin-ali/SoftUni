using System;
using System.Collections.Generic;
using System.Linq;

namespace _03_tseam_account
{
    class TseamAccount
    {
        static void Main()
        {
            var account = Console.ReadLine().Split().ToList();

            var input = Console.ReadLine();
            while (input != "Play!")
            {
                var info = input.Split(new[] { ' ', '-' }, StringSplitOptions.RemoveEmptyEntries);
                var command = info[0];
                var game = info[1];

                if (command == "Install" && !account.Contains(game))
                {
                    account.Add(game);
                }
                else if (command == "Uninstall")
                {
                    account.Remove(game);
                }
                else if (command == "Update" && account.Remove(game))
                {
                    account.Add(game);
                }
                else if (command == "Expansion")
                {
                    var expansion = $"{game}:{info[2]}";
                    var indexOfGame = account.IndexOf(game);

                    if (indexOfGame >= 0)
                    {
                        account.Insert(indexOfGame + 1, expansion);
                    }
                }

                input = Console.ReadLine();
            }

            var games = string.Join(" ", account);
            Console.WriteLine(games);
        }
    }
}
/*

CS WoW Diablo
Install LoL
Uninstall WoW
Update Diablo
Expansion CS-Go
Play!

CS WoW Diablo
Uninstall XCOM
Update PeshoGame
Update WoW
Expansion Civ-V
Play!

 */
