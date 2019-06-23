using System;

namespace _08_threeuple
{
    class ThreeupleStartup
    {
        static void Main()
        {
            var nameAddressAndTown = Console.ReadLine().Split();
            var person1Name = $"{nameAddressAndTown[0]} {nameAddressAndTown[1]}";
            var address = nameAddressAndTown[2];
            var town = nameAddressAndTown[3];

            var nameBeerCapacityAndDrunkState = Console.ReadLine().Split();
            var person2Name = nameBeerCapacityAndDrunkState[0];
            var beerCapacityLitres = int.Parse(nameBeerCapacityAndDrunkState[1]);
            var isDrunk = nameBeerCapacityAndDrunkState[2] == "drunk";

            var nameAccountBalanceAndBankName = Console.ReadLine().Split();
            var name = nameAccountBalanceAndBankName[0];
            var @double = double.Parse(nameAccountBalanceAndBankName[1]);
            var bankName = nameAccountBalanceAndBankName[2];

            var tuple1 = new Threeuple<string, string, string> { Item1 = person1Name, Item2 = address, Item3 = town };
            Console.WriteLine(tuple1);

            var tuple2 = new Threeuple<string, int, bool> { Item1 = person2Name, Item2 = beerCapacityLitres, Item3 = isDrunk };
            Console.WriteLine(tuple2);

            var tuple3 = new Threeuple<string, double, string> { Item1 = name, Item2 = @double, Item3 = bankName };
            Console.WriteLine(tuple3);
        }
    }
}
