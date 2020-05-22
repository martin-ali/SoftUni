namespace _08_military_elite
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using _08_military_elite.Interfaces;
    using _08_military_elite.Models;

    class Startup
    {
        private const string END_COMMAND = "End";

        static void Main()
        {
            // #if DEBUG
            //             Console.SetIn(new StreamReader("tests/test1.txt"));
            // #endif

            var privatesById = new Dictionary<string, IPrivate>();
            var input = Console.ReadLine();
            while (input != END_COMMAND)
            {
                var data = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                var position = data[0];
                var id = data[1];
                var firstName = data[2];
                var lastName = data[3];

                if (position == "Spy")
                {
                    var codeNumber = int.Parse(data[4]);

                    var spy = new Spy(id, firstName, lastName, codeNumber);
                    input = Console.ReadLine();

                    continue;
                }

                var salary = decimal.Parse(data[4]);

                ISoldier someName = null;
                if (position == "Private")
                {
                    var privateSoldier = new Private(id, firstName, lastName, salary);

                    privatesById[id] = privateSoldier;
                    someName = privateSoldier;
                }
                else if (position == "LieutenantGeneral")
                {
                    var privates = data.Skip(5).Select(p => privatesById[p]).ToList();

                    var leutenantGeneral = new LieutenantGeneral(id, firstName, lastName, salary, privates);
                    someName = leutenantGeneral;
                }
                else if (position == "Engineer")
                {
                    try
                    {
                        var corps = data[5];

                        var repairs = new List<IRepair>();
                        var repairsData = data.Skip(6).ToArray();
                        for (int current = 0; current < repairsData.Length; current += 2)
                        {
                            try
                            {
                                var partName = repairsData[current];
                                var hoursWorked = int.Parse(repairsData[current + 1]);

                                var repair = new Repair(partName, hoursWorked);
                                repairs.Add(repair);
                            }
                            catch (System.Exception) { }
                        }

                        var engineer = new Engineer(id, firstName, lastName, salary, corps, repairs);
                        someName = engineer;
                    }
                    catch (System.Exception)
                    {
                    }
                }
                else if (position == "Commando")
                {
                    try
                    {
                        var corps = data[5];

                        var missions = new HashSet<IMission>();
                        var missionsData = data.Skip(6).ToArray();
                        for (int current = 0; current < missionsData.Length; current += 2)
                        {
                            try
                            {
                                var codeName = missionsData[current];
                                var state = missionsData[current + 1];

                                var mission = new Mission(codeName, state);
                                missions.Add(mission);
                            }
                            catch (System.Exception) { }
                        }

                        var commando = new Commando(id, firstName, lastName, salary, corps, missions);
                        someName = commando;
                    }
                    catch (System.Exception)
                    {
                    }
                }

                if (someName != null)
                {
                    Console.WriteLine(someName);
                }

                input = Console.ReadLine();
            }
        }
    }
}
/*

Private 1 Pesho Peshev 22.22
Commando 13 Stamat Stamov 13.1 Airforces
Private 222 Toncho Tonchev 80.08
LieutenantGeneral 3 Joro Jorev 100 222 1
End

Engineer 7 Pencho Penchev 12.23 Marines Boat 2 Crane 17
Commando 19 Penka Ivanova 150.15 Airforces HairyFoot finished Freedom inProgress
End

*/
