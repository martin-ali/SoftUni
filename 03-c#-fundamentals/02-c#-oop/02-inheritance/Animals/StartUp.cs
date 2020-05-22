namespace Animals
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Reflection;

    public class StartUp
    {
        public static void Main()
        {
#if DEBUG
            Console.SetIn(new StreamReader("tests/test4.txt"));
#endif
            var animals = new List<Animal>();

            var input = Console.ReadLine();
            while (input != "Beast!")
            {
                try
                {
                    var species = input;
                    var parameters = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);

                    var animal = CreateAnimal(species, parameters);

                    Console.Write(animal);
                }
                catch (ArgumentException exception)
                {
                    Console.WriteLine(exception.Message);
                }

                input = Console.ReadLine();
            }
        }

        // private static Animal CreateAnimal(string species, string[] parameters)
        // {
        //     var name = parameters[0];
        //     var age = int.Parse(parameters[1]);
        //     var gender = parameters[2];

        //     // Should avoid null in the future
        //     Animal animal = null;
        //     switch (species)
        //     {
        //         case nameof(Dog): animal = new Dog(name, age, gender); break;
        //         case nameof(Frog): animal = new Frog(name, age, gender); break;
        //         case nameof(Cat): animal = new Cat(name, age, gender); break;
        //         case nameof(Tomcat): animal = new Tomcat(name, age); break;
        //         case nameof(Kitten): animal = new Kitten(name, age); break;
        //     }

        //     return animal;
        // }

        private static Animal CreateAnimal(string species, string[] parameters)
        {
            var name = parameters[0];
            var age = int.Parse(parameters[1]);
            var gender = parameters[2];

            var assembly = Assembly.GetExecutingAssembly();
            var type = assembly
                        .GetTypes()
                        .First(t => t.Name == species);

            var constructor = type.GetConstructor(new Type[] { typeof(string), typeof(int), typeof(string) });

            Animal animal = null;
            if (constructor == null)
            {
                constructor = type.GetConstructor(new Type[] { typeof(string), typeof(int) });
                animal = (Animal)constructor.Invoke(new object[] { name, age });
            }
            else
            {
                animal = (Animal)constructor.Invoke(new object[] { name, age, gender });
            }

            return animal;
        }
    }
}
/*

Cat
Tom 12 Male
Dog
Sharo 132 Male
Beast!

Frog
Kermit 12 Male
Beast!

Frog
Sashko -2 Male
Frog
Sashko 2 Male
Beast!

*/
