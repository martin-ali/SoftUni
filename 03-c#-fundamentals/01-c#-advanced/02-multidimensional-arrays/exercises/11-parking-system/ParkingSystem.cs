using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace _11_parking_system
{
    class ParkingSystem
    {
        static void Main()
        {
#if DEBUG
            Console.SetIn(new StreamReader("tests/test1.txt"));
#endif

            var parkingLotDimensions = Console.ReadLine()
                                        .Split(' ')
                                        .Select(int.Parse)
                                        .ToArray();
            var rows = parkingLotDimensions[0];
            var cols = parkingLotDimensions[1];

            var parkingLot = new Dictionary<int, HashSet<int>>();

            var input = Console.ReadLine();
            while (input != "stop")
            {
                var targetSpotData = input
                                        .Split()
                                        .Select(int.Parse)
                                        .ToArray();

                var entryRow = targetSpotData[0];
                var targetRow = targetSpotData[1];
                var targetCol = targetSpotData[2];

                if (parkingLot.ContainsKey(targetRow) == false)
                {
                    parkingLot[targetRow] = new HashSet<int>();
                }

                var spotIsTaken = parkingLot[targetRow].Contains(targetCol);
                if (spotIsTaken)
                {
                    targetCol = FindNewSpot(parkingLot, targetRow, targetCol, cols);
                }

                bool carCanPark = targetCol > 0;
                if (carCanPark)
                {
                    var rowDifference = Math.Abs(targetRow - entryRow);
                    var colDifference = targetCol;

                    parkingLot[targetRow].Add(targetCol);

                    var cellsTraversed = rowDifference + colDifference + 1;
                    Console.WriteLine(cellsTraversed);
                }
                else
                {
                    Console.WriteLine($"Row {targetRow} full");
                }

                input = Console.ReadLine();
            }
        }

        private static int FindNewSpot(Dictionary<int, HashSet<int>> parkingLot, int targetRow, int targetCol, int colCount)
        {

            var bestDistance = int.MaxValue;
            var bestCol = -1;

            for (int col = 1; col < colCount; col++)
            {
                int distance = Math.Abs(targetCol - col);
                if (parkingLot[targetRow].Contains(col) == false && distance < bestDistance)
                {
                    bestCol = col;
                    bestDistance = distance;
                }
            }

            return bestCol;
        }
    }
}
