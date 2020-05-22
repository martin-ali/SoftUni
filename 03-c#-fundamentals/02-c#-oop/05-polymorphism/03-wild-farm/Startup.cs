namespace _03_wild_farm
{
    using System;
    using System.Collections.Generic;
    using _03_wild_farm.Models.Animals;
    using _03_wild_farm.Models.Animals.Birds;
    using _03_wild_farm.Models.Animals.Mammals;
    using _03_wild_farm.Models.Animals.Mammals.Felines;
    using _03_wild_farm.Models.Foods;

    class Startup
    {
        static void Main()
        {
            var animals = new List<Animal>();
            var input = Console.ReadLine();
            while (input != "End")
            {
                var animal = CreateAnimal(input.Split(' '));
                var food = CreateFood(Console.ReadLine().Split(' '));

                Console.WriteLine(animal.MakeSound());
                try
                {
                    animal.Eat(food);
                }
                catch (ArgumentException exception)
                {
                    Console.WriteLine(exception.Message);
                }

                animals.Add(animal);

                input = Console.ReadLine();
            }

            foreach (var animal in animals)
            {
                Console.WriteLine(animal);
            }
        }

        private static Food CreateFood(string[] data)
        {
            var type = data[0];
            var quantity = int.Parse(data[1]);

            // Avoid null in the future
            Food food = null;
            switch (type)
            {
                case nameof(Fruit): food = new Fruit(quantity); break;
                case nameof(Meat): food = new Meat(quantity); break;
                case nameof(Seeds): food = new Seeds(quantity); break;
                case nameof(Vegetable): food = new Vegetable(quantity); break;
            }

            return food;
        }

        private static Animal CreateAnimal(string[] data)
        {
            var species = data[0];
            var name = data[1];

            // Avoid null in the future
            Animal animal = null;
            switch (species)
            {
                case nameof(Hen): animal = new Hen(name, double.Parse(data[2]), double.Parse(data[3])); break;
                case nameof(Owl): animal = new Owl(name, double.Parse(data[2]), double.Parse(data[3])); break;
                case nameof(Cat): animal = new Cat(name, double.Parse(data[2]), data[3], data[4]); break;
                case nameof(Tiger): animal = new Tiger(name, double.Parse(data[2]), data[3], data[4]); break;
                case nameof(Dog): animal = new Dog(name, double.Parse(data[2]), data[3]); break;
                case nameof(Mouse): animal = new Mouse(name, double.Parse(data[2]), data[3]); break;
            }

            return animal;
        }
    }
}
/*

Cat Pesho 1.1 Home Persian
Vegetable 4
End

Tiger Typcho 167.7 Asia Bengal
Vegetable 1
Dog Doncho 500 Street
Vegetable 150
End

Mouse Jerry 0.5 Anywhere
Fruit 1000
Owl Toncho 2.5 30
Meat 5
End

Hen Pesho 1 25
Vegetable 4
Tiger Typcho 167.7 Asia Bengal
Vegetable 1
Tiger Umcho 167.7 Asia Bengal
Meat 1
Dog Doncho 500 Street
Vegetable 150
Dog Boncho 500 Street
Meat 150
End

*/
