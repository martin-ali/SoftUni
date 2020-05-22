namespace _02_car_salesman
{
    using System;
    using System.Collections.Generic;

    class CarSalesman
    {
        static void Main()
        {
            var enginesByModel = new Dictionary<string, Engine>();
            var engineCount = int.Parse(Console.ReadLine());
            for (int i = 0; i < engineCount; i++)
            {
                var engine = Engine.Parse(Console.ReadLine());

                enginesByModel[engine.Model] = engine;
            }

            var carCount = int.Parse(Console.ReadLine());
            for (int i = 0; i < carCount; i++)
            {
                var car = Car.Parse(Console.ReadLine(), enginesByModel);
                Console.WriteLine(car);
            }
        }
    }
}