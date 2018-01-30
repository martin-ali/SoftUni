using System;

namespace Animal_Type
{
    class Program
    {
        static void Main()
        {
            var animal = Console.ReadLine();
            var animalType = "unknown";

            switch (animal)
            {
                case "dog":
                    animalType = "mammal";
                    break;
                case "crocodile":
                    animalType = "reptile";
                    break;
                case "tortoise":
                    animalType = "reptile";
                    break;
                case "snake":
                    animalType = "reptile";
                    break;
                default:
                    break;
            }

            Console.WriteLine(animalType);
        }
    }
}
