using System;

namespace _07_tuple
{
    class TupleStartup
    {
        static void Main()
        {
            var nameAndAddress = Console.ReadLine().Split();
            var person1Name = $"{nameAndAddress[0]} {nameAndAddress[1]}";
            var address = nameAndAddress[2];

            var nameAndBeerCapacity = Console.ReadLine().Split();
            var person2Name = nameAndBeerCapacity[0];
            var beerCapacityLitres = int.Parse(nameAndBeerCapacity[1]);

            var integerAndDouble = Console.ReadLine().Split();
            var integer = int.Parse(integerAndDouble[0]);
            var @double = double.Parse(integerAndDouble[1]);

            var tuple1 = new Tuple<string, string> { Item1 = person1Name, Item2 = address };
            Console.WriteLine(tuple1);

            var tuple2 = new Tuple<string, int> { Item1 = person2Name, Item2 = beerCapacityLitres };
            Console.WriteLine(tuple2);

            var tuple3 = new Tuple<int, double> { Item1 = integer, Item2 = @double };
            Console.WriteLine(tuple3);
        }
    }
}
