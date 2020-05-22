namespace _07_food_shortage
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Linq;
    using _07_food_shortage.Interfaces;
    using _07_food_shortage.Models;

    class Startup
    {
        private const string END_COMMAND = "End";

        static void Main()
        {
            var buyerByName = new Dictionary<string, IBuyer>();
            var peopleCount = int.Parse(Console.ReadLine());
            for (int i = 0; i < peopleCount; i++)
            {
                var data = Console.ReadLine().Split(' ');
                var name = data[0];
                var age = int.Parse(data[1]);

                if (data.Length == 3)
                {
                    var group = data[2];

                    buyerByName[name] = new Rebel(name, age, group);
                }
                else if (data.Length == 4)
                {
                    var id = data[2];
                    var birthDate = DateTime.ParseExact(data[3], "dd/MM/yyyy", CultureInfo.InvariantCulture);

                    buyerByName[name] = new Citizen(name, age, id, birthDate);
                }
            }

            var input = Console.ReadLine();
            while (input != END_COMMAND)
            {
                var buyerName = input;
                if (buyerByName.TryGetValue(buyerName, out IBuyer buyer))
                {
                    buyer.BuyFood();
                }

                input = Console.ReadLine();
            }

            var totalFoodBought = buyerByName.Values.Sum(b => b.Food);
            Console.WriteLine(totalFoodBought);
        }
    }
}
/*

2
Pesho 25 8904041303 04/04/1989
Stancho 27 WildMonkeys
Pesho
Gosho
Pesho
End

4
Stamat 23 TheSwarm
Toncho 44 7308185527 18/08/1973
Joro 31 Terrorists
Penka 27 881222212 22/12/1988
Jiraf
Jo ro
Jiraf
Joro
Stamat
Penka
End

*/
