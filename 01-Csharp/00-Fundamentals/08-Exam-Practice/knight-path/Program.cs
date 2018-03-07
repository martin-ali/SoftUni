using System;
using System.Collections.Generic;

namespace knight_path
{
    class Program
    {
        // Tuples da shit, mun!
        // Should be careful and avoid turning my code into JavaScript with Anonymous Types and Tuples
        // Dynamic remains useless
        private static Dictionary<string, (int x, int y)> directions = new Dictionary<string, (int x, int y)>
        {
            ["left up"] = (-2, -1),
            ["left down"] = (-2, 1),
            ["right up"] = (2, -1),
            ["right down"] = (2, 1),
            ["up left"] = (-1, -2),
            ["up right"] = (1, -2),
            ["down left"] = (-1, 2),
            ["down right"] = (1, 2)
        };

        static void Main()
        {
            var moves = new List<string>()
            {
                "left down",
                "down right",
                "right up",
                "down right",
                "left down",
                "left down"
            };
            var board = new bool[8, 8];
            var currentKnightX = 7;
            var currentKnightY = 0;

            // while (true)
            // {
            //     var command = Console.ReadLine().ToLower();

            //     if (command == "stop")
            //     {
            //         break;
            //     }
            //     else
            //     {
            //         moves.Add(command);
            //     }
            // }

            // board[0, 7] = true;
            foreach (string move in moves)
            {
                var newCoordinates = ExecuteOnBoard(board, move, currentKnightX, currentKnightY);
                currentKnightX = newCoordinates.x;
                currentKnightY = newCoordinates.y;
            }

            // Print board
            PrintGameBoard(board);
        }

        private static void PrintGameBoard(bool[,] board)
        {
            var shit = false;
            for (int row = 0; row < 8; row++)
            {
                double number = 0;
                for (int col = 7; col >= 0; col--)
                {
                    if (board[row, col])
                    {
                        number += Math.Pow(2, col - 7);
                    }
                }

                if (number != 0)
                {
                    shit = true;
                    Console.WriteLine(number);
                }
            }

            if (shit)
            {
                Console.WriteLine("[Board is empty]");
            }
        }

        static (int x, int y) ExecuteOnBoard(bool[,] board, string command, int currentX, int currentY)
        {
            var commandParts = command.Split(" ");

            var nextMove = directions[command];
            var newX = currentX + nextMove.x;
            var newY = currentY + nextMove.y;

            var newCoordinates = (currentX, currentY);
            bool movementIsValid = 0 <= newX && newX <= 7 && 0 <= newY && newY <= 7;
            if (movementIsValid)
            {
                board[currentX, currentY] = !board[currentX, currentY];
                newCoordinates = (newX, newY);
            }

            return newCoordinates;
        }
    }
}