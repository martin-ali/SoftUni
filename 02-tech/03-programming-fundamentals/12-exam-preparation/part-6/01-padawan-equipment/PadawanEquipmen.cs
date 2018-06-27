using System;

namespace _01_padawan_equipment
{
    class PadawanEquipmen
    {
        static void Main()
        {
            var budget = decimal.Parse(Console.ReadLine());
            var studentCount = int.Parse(Console.ReadLine());
            var lightsaberPrice = decimal.Parse(Console.ReadLine());
            var robePrice = decimal.Parse(Console.ReadLine());
            var beltPrice = decimal.Parse(Console.ReadLine());

            var lightsaberCount = (int)Math.Ceiling(studentCount * 1.1);
            var beltCount = studentCount - (studentCount / 6);
            // var beltCount = studentCount - (studentCount % 6);

            var price = (lightsaberCount * lightsaberPrice)
                        + (studentCount * robePrice)
                        + (beltCount * beltPrice);

            if (budget >= price)
            {
                Console.WriteLine($"The money is enough - it would cost {price:0.00}lv.");
            }
            else
            {
                var difference = price - budget;
                Console.WriteLine($"Ivan Cho will need {difference:0.00}lv more.");
            }
        }
    }
}
/*

100
2
1.0
2.0
3.0

100
42
12.0
4.0
3.0

 */
