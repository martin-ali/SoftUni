namespace _04_pizza_calories
{
    using System;
    using System.IO;

    class Startup
    {
        static void Main()
        {
            try
            {
                var name = Console.ReadLine().Replace("Pizza ", string.Empty);
                var doughData = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);

                var flour = doughData[1];
                var bakingTechnique = doughData[2];
                var doughWeight = int.Parse(doughData[3]);

                var dough = new Dough(flour, bakingTechnique, doughWeight);
                var pizza = new Pizza(name, dough);

                var input = Console.ReadLine();
                while (input != "END")
                {
                    var toppingData = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                    var type = toppingData[1];
                    var weight = int.Parse(toppingData[2]);

                    pizza.AddTopping(type, weight);

                    input = Console.ReadLine();
                }

                Console.WriteLine(pizza);
            }
            catch (ArgumentException exception)
            {
                Console.WriteLine(exception.Message);
            }
        }
    }
}
/*

Pizza Meatless
Dough Wholegrain Crispy 100
Topping Veggies 50
Topping Cheese 50
END

Pizza Burgas
Dough White Homemade 200
Topping Meat 123
END

Pizza Bulgarian
Dough White Chewy 100
Topping Sauce 20
Topping Cheese 50
Topping Cheese 40
Topping Meat 10
Topping Sauce 10
Topping Cheese 30
Topping Cheese 40
Topping Meat 20
Topping Sauce 30
Topping Cheese 25
Topping Cheese 40
Topping Meat 40
END

Pizza Bulgarian
Dough White Chewy 100
Topping Sirene 50
Topping Cheese 50
Topping Krenvirsh 20
Topping Meat 10
END

*/
