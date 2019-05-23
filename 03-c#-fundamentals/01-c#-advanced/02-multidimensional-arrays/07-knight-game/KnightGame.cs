using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace _07_knight_game
{
    class KnightGame
    {
        private const char KNIGHT = 'K';
        private const char EMPTY = ' ';

        static void Main()
        {
#if DEBUG
            Console.SetIn(new StreamReader("tests/test4.txt"));
#endif

            var boardSize = int.Parse(Console.ReadLine());
            var board = CreateBoard(boardSize);

            #region Alternative method(Not solution)
            // var knights = new Queue<(int row, int col, int opponentsCount)>();
            // for (int row = 0; row < boardSize; row++)
            // {
            //     for (int col = 0; col < boardSize; col++)
            //     {
            //         if (board[row, col] == KNIGHT)
            //         {
            //             var opponentsCount = GetKnightOpponentsCount(board, row, col);
            //             var knight = (row, col, opponentsCount);
            //             knights.Enqueue(knight);
            //         }
            //     }
            // }

            // var initialKnightCount = knights.Count;
            // knights = new Queue<(int row, int col, int opponentsCount)>(knights.OrderByDescending(x => x.opponentsCount));

            // while (knights.Any(x => x.opponentsCount > 0))
            // {
            //     var knight = knights.Dequeue();
            //     board[knight.row, knight.col] = EMPTY;

            //     knights = new Queue<(int row, int col, int opponentsCount)>(knights
            //     .Select(x => (row: x.row, col: x.col, opponentsCount: GetKnightOpponentsCount(board, x.row, x.col)))
            //     .OrderByDescending(x => x.opponentsCount));
            // }

            // var removedKnightsCount = initialKnightCount - knights.Count;
            // Console.WriteLine(removedKnightsCount);
            #endregion

            #region Working solution
            var removedKnightsCount = 0;
            while (true)
            {
                var knightWithMostOpponents = (row: -1, col: -1, opponentsCount: int.MinValue);

                for (int row = 0; row < board.GetLength(0); row++)
                {
                    for (int col = 0; col < board.GetLength(1); col++)
                    {
                        if (board[row, col] == KNIGHT)
                        {
                            var opponentsCount = GetKnightOpponentsCount(board, row, col);

                            if (opponentsCount > knightWithMostOpponents.opponentsCount)
                            {
                                knightWithMostOpponents = (row, col, opponentsCount);
                            }
                        }
                    }
                }

                if (knightWithMostOpponents.opponentsCount > 0)
                {
                    board[knightWithMostOpponents.row, knightWithMostOpponents.col] = EMPTY;
                    removedKnightsCount++;
                }
                else
                {
                    break;
                }
            }

            Console.WriteLine(removedKnightsCount);
            #endregion
        }

        private static int GetKnightOpponentsCount(char[,] board, int row, int col)
        {
            var neighbours = new (int rowUpdate, int colUpdate)[]
            {
                (1,2),
                (1,-2),
                (-1,2),
                (-1,-2),
                (2,1),
                (2,-1),
                (-2,1),
                (-2,-1),
            };

            var opponentsCount = 0;
            foreach (var coordinates in neighbours)
            {
                var newRow = row + coordinates.rowUpdate;
                int newCol = col + coordinates.colUpdate;
                if (IsInRange(board, newRow, newCol) && board[newRow, newCol] == KNIGHT)
                {
                    opponentsCount++;
                }
            }

            return opponentsCount;
        }

        private static bool IsInRange<G>(G[,] board, int row, int col)
        {
            return 0 <= row && row < board.GetLength(0)
                && 0 <= col && col < board.GetLength(1);
        }

        private static char[,] CreateBoard(int size)
        {
            var matrix = new char[size, size];
            for (int row = 0; row < size; row++)
            {
                var items = Console.ReadLine().Trim().ToCharArray();
                var col = 0;
                foreach (var item in items)
                {
                    matrix[row, col++] = item;
                }
            }

            return matrix;
        }
    }
}