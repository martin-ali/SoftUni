using System;
using System.Collections.Generic;
using System.Linq;

namespace _04_trainlands
{
    class Trainlands
    {
        static void Main()
        {
            var wagonsByTrain = new Dictionary<string, List<(string name, int power)>>();

            var input = Console.ReadLine();
            while (input != "It's Training Men!")
            {
                if (input.Contains('='))
                {
                    var command = input.Split(new[] { " = " }, StringSplitOptions.RemoveEmptyEntries);
                    var train = command[0];
                    var otherTrain = command[1];

                    if (wagonsByTrain.ContainsKey(train) == false)
                    {
                        wagonsByTrain[train] = new List<(string name, int power)>();
                    }

                    wagonsByTrain[train] = wagonsByTrain[otherTrain].ToList();
                }
                else if (input.Contains(':'))
                {
                    var command = input.Split(new[] { " -> ", " : " }, StringSplitOptions.RemoveEmptyEntries);
                    var train = command[0];
                    var wagon = command[1];
                    var power = int.Parse(command[2]);

                    if (wagonsByTrain.ContainsKey(train) == false)
                    {
                        wagonsByTrain[train] = new List<(string name, int power)>();
                    }

                    wagonsByTrain[train].Add((wagon, power));
                }
                else
                {
                    var command = input.Split(new[] { " -> " }, StringSplitOptions.RemoveEmptyEntries);
                    var train = command[0];
                    var otherTrain = command[1];

                    if (wagonsByTrain.ContainsKey(train) == false)
                    {
                        wagonsByTrain[train] = new List<(string name, int power)>();
                    }

                    wagonsByTrain[train].AddRange(wagonsByTrain[otherTrain]);
                    wagonsByTrain.Remove(otherTrain);
                }

                input = Console.ReadLine();
            }

            var orderedWagonsByTrain = wagonsByTrain
                                .OrderByDescending(t => t.Value.Sum(x => x.power))
                                .ThenBy(t => t.Value.Count);
            foreach (var train in orderedWagonsByTrain)
            {
                Console.WriteLine($"Train: {train.Key}");

                var orderedWagons = train.Value.OrderByDescending(w => w.power);
                foreach (var wagon in orderedWagons)
                {
                    Console.WriteLine($"###{wagon.name} - {wagon.power}");
                }
            }
        }
    }
}
/*

Kivil -> KAKA : 1387
Zone -> Gh : 4081
Kivil -> RAMZES666 : 4677
Desolator -> MiraclE~ : 8432
Zone -> Kivil
It's Training Men!

Kepler -> MinD_ContRoL : 3782
Daun -> Fn : 6816
Miner -> Gh : 1198
Miner -> Sccc : 9030
Miner -> KAKA : 7409
Anna -> Miner
Daun = Anna
It's Training Men!

 */
