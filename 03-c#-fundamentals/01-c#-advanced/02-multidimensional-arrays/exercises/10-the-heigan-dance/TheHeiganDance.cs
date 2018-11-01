using System;
using System.IO;

namespace _10_the_heigan_dance
{
    class TheHeiganDance
    {
        private const int PLAGUE_CLOUD_DAMAGE = 3500;

        private const int ERUPTION_DAMAGE = 6000;

        private static string eruption = "Eruption";

        private static string plagueCloud = "Plague Cloud";

        private static string lastAttack = "";

        private static bool playerExpectsHitFromCloud = false;

        static void Main()
        {
#if DEBUG
            Console.SetIn(new StreamReader("tests/test3.txt"));
#endif

            var heigan = (health: 3_000_000D, status: "", lastAttack: "");
            var player = (health: 18_500D, row: 7, col: 7, status: "");
            var damageToHeiganPerTurn = double.Parse(Console.ReadLine());

            while (true)
            {
                heigan.health -= damageToHeiganPerTurn;

                if (playerExpectsHitFromCloud)
                {
                    player.health -= PLAGUE_CLOUD_DAMAGE;
                    playerExpectsHitFromCloud = false;
                }

                bool heiganIsDead = heigan.health <= 0;
                bool playerIsDead = player.health <= 0;
                if (playerIsDead || heiganIsDead)
                {
                    player.status = player.health > 0
                                    ? player.health.ToString()
                                    : $"Killed by {lastAttack}";
                    heigan.status = heigan.health > 0
                                    ? heigan.health.ToString("0.00")
                                    : "Defeated!";
                    break;
                }

                var attackData = Console.ReadLine().Split();
                var spell = attackData[0];
                var attackRow = int.Parse(attackData[1]);
                var attackCol = int.Parse(attackData[2]);

                if (playerIsInDamageArea(player.row, player.col, attackRow, attackCol))
                {
                    var newCoordinates = GetNewCoordinates(player.row, player.col, attackRow, attackCol);
                    player.row = newCoordinates.row;
                    player.col = newCoordinates.col;
                }

                if (heigan.health > 0 && playerIsInDamageArea(player.row, player.col, attackRow, attackCol))
                {
                    if (spell == eruption)
                    {
                        lastAttack = eruption;
                        player.health -= ERUPTION_DAMAGE;
                    }
                    else
                    {
                        lastAttack = plagueCloud;
                        player.health -= PLAGUE_CLOUD_DAMAGE;
                        playerExpectsHitFromCloud = true;
                    }
                }

                playerIsDead = player.health <= 0;
                if (playerIsDead)
                {
                    heigan.status = heigan.health.ToString("0.00");
                    player.status = $"Killed by {lastAttack}";
                    break;
                }
            }

            Console.WriteLine($"Heigan: {heigan.status}");
            Console.WriteLine($"Player: {player.status}");
            Console.WriteLine($"Final position: {player.row}, {player.col}");
        }

        private static bool playerIsInDamageArea(int playerRow, int playerCol, int attackRow, int attackCol)
        {
            var attackStartRow = attackRow - 1;
            var attackEndRow = attackRow + 1;
            var attackStartCol = attackCol - 1;
            var attackEndCol = attackCol + 1;

            var playerIsInAttackRow = attackStartRow <= playerRow && playerRow <= attackEndRow;
            var playerIsInAttackCol = attackStartCol <= playerCol && playerCol <= attackEndCol;

            return playerIsInAttackRow && playerIsInAttackCol;
        }

        private static (int row, int col) GetNewCoordinates(int playerRow, int playerCol, int attackRow, int attackCol)
        {
            var newRow = playerRow;
            var newCol = playerCol;

            if (IsInChamber(playerRow - 1, playerCol)
                && playerIsInDamageArea(playerRow - 1, playerCol, attackRow, attackCol) == false)
            {
                newRow--;
            }
            else if (IsInChamber(playerRow, playerCol + 1)
                && playerIsInDamageArea(playerRow, playerCol + 1, attackRow, attackCol) == false)
            {
                newCol++;
            }
            else if (IsInChamber(playerRow + 1, playerCol)
                && playerIsInDamageArea(playerRow + 1, playerCol, attackRow, attackCol) == false)
            {
                newRow++;
            }
            else if (IsInChamber(playerRow, playerCol - 1)
                && playerIsInDamageArea(playerRow, playerCol - 1, attackRow, attackCol) == false)
            {
                newCol--;
            }

            return (newRow, newCol);
        }

        private static bool IsInChamber(int row, int col)
        {
            return 0 <= row && row < 15
                && 0 <= col && col < 15;
        }
    }
}
