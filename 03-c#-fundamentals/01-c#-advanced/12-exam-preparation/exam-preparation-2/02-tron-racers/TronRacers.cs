using System;
using System.Collections.Generic;
using System.Linq;

namespace _02_tron_racers
{
    class TronRacers
    {
        private const char Dead = 'x';

        private const char Empty = '*';

        static void Main()
        {
            var size = int.Parse(Console.ReadLine());
            var field = new List<List<char>>();

            var player1 = (row: 0, col: 0, marker: 'f');
            var player2 = (row: 0, col: 0, marker: 's');

            for (int row = 0; row < size; row++)
            {
                var col = Console.ReadLine()
                            .ToCharArray()
                            .ToList();
                field.Add(col);

                var player1Col = field[row].IndexOf(player1.marker);
                var player2Col = field[row].IndexOf(player2.marker);

                if (player1Col >= 0)
                {
                    player1.row = row;
                    player1.col = player1Col;
                }

                if (player2Col >= 0)
                {
                    player2.row = row;
                    player2.col = player2Col;
                }
            }

            while (true)
            {
                var playersInput = Console.ReadLine().Split();
                var player1Direction = playersInput[0];
                var player2Direction = playersInput[1];

                var newPlayer1 = LoopIfNeeded(size, GetNewCoordinates(player1, player1Direction));
                var newPlayer2 = LoopIfNeeded(size, GetNewCoordinates(player2, player2Direction));

                // FIXME: Repeated code
                if (field[newPlayer1.row][newPlayer1.col] == player2.marker)
                {
                    field[newPlayer1.row][newPlayer1.col] = Dead;
                    break;
                }

                player1 = newPlayer1;
                field[player1.row][player1.col] = player1.marker;

                if (field[newPlayer2.row][newPlayer2.col] == player1.marker)
                {
                    field[newPlayer2.row][newPlayer2.col] = Dead;
                    break;
                }

                player2 = newPlayer2;
                field[player2.row][player2.col] = player2.marker;
            }

            PrintField(field);
        }

        private static (int row, int col, char marker) LoopIfNeeded(int size, (int row, int col, char marker) player)
        {
            if (player.row < 0)
            {
                player.row += size;
            }
            else if (player.row >= size)
            {
                player.row -= size;
            }
            else if (player.col < 0)
            {
                player.col += size;
            }
            else if (player.col >= size)
            {
                player.col -= size;
            }

            // player.row %= size;
            // player.col %= size;

            return player;
        }

        private static (int row, int col, char marker) GetNewCoordinates((int row, int col, char marker) player, string direction)
        {
            switch (direction)
            {
                case "up": player.row--; break;
                case "down": player.row++; break;
                case "left": player.col--; break;
                case "right": player.col++; break;
            }

            return player;
        }

        private static void PrintField(List<List<char>> field)
        {
            foreach (var row in field)
            {
                Console.WriteLine(new string(row.ToArray()));
            }
        }
    }
}
/*

 5
***f*
**s**
*****
*****
*****
down down
right down
down right
down down
down left
left left

 4
*f**
****
**s*
****
down up
down right
right right

*/
