namespace _06_birthday_celebrations
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Linq;
    using _06_birthday_celebrations.Interfaces;
    using _06_birthday_celebrations.Models;

    class Startup
    {
        static void Main()
        {
            var inhabitants = new List<IHasBirthdate>();

            var input = Console.ReadLine();
            while (input != "End")
            {
                var data = input.Split(' ');

                if (data.Length == 3 && data[0] != "Robot")
                {
                    var name = data[1];
                    var birthDate = DateTime.ParseExact(data[2], "dd/MM/yyyy", CultureInfo.InvariantCulture);

                    var pet = new Pet(name, birthDate);

                    inhabitants.Add(pet);
                }
                else if (data.Length == 5)
                {
                    var name = data[1];
                    var age = int.Parse(data[2]);
                    var id = data[3];
                    var birthDate = DateTime.ParseExact(data[4], "dd/MM/yyyy", CultureInfo.InvariantCulture);

                    var citizen = new Citizen(name, age, id, birthDate);
                    inhabitants.Add(citizen);
                }

                input = Console.ReadLine();
            }

            var year = int.Parse(Console.ReadLine());
            var detainedInhabitants = inhabitants.Where(i => i.BirthDate.Year == year);

            foreach (var detainedInhabitant in detainedInhabitants)
            {
                Console.WriteLine($"{detainedInhabitant.BirthDate:dd/MM/yyyy}");
            }
        }
    }
}
/*

Citizen Pesho 22 9010101122 10/10/1990
Pet Sharo 13/11/2005
Robot MK-13 558833251
End
1990

Citizen Stamat 16 0041018380 01/01/2000
Robot MK-10 12345678
Robot PP-09 00000001
Pet Topcho 24/12/2000
Pet Kosmat 12/06/2002
End
2000

Robot VV-XYZ 11213141
Citizen Penka 35 7903210713 21/03/1979
Citizen Kane 40 7409073566 07/09/1974
End
1975

*/
