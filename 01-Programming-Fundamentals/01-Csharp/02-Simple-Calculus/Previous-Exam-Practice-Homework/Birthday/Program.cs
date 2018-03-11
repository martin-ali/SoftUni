using System;

namespace Birthday
{
    class Program
    {
        static void Main()
        {
            var length = uint.Parse(Console.ReadLine());
            var width = uint.Parse(Console.ReadLine());
            var height = uint.Parse(Console.ReadLine());
            var takenSpace = float.Parse(Console.ReadLine());

            var volume = length * width * height;
            var litersAquariumCanTake = volume * 0.001;
            var percentageTakenSpace = takenSpace * 0.01;
            var result = litersAquariumCanTake * (1 - percentageTakenSpace);
            var roundedResult = result.ToString("0.000");

            Console.WriteLine(roundedResult);
        }
    }
}
