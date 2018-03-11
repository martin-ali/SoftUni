using System;

namespace Pool_Tubes
{
    class Program
    {
        static void Main()
        {
            //var poolCapacity = 1000;
            //var firstTubeDebit = 100;
            //var secondTubeDebit = 120;
            //var howLongWorkerIsMissing = 3d;

            var poolCapacity = double.Parse(Console.ReadLine());
            var firstTubeDebit = double.Parse(Console.ReadLine());
            var secondTubeDebit = double.Parse(Console.ReadLine());
            var howLongWorkerIsMissing = double.Parse(Console.ReadLine());

            double volumeByFirstTube = firstTubeDebit * howLongWorkerIsMissing;
            double volumeBySecondTube = secondTubeDebit * howLongWorkerIsMissing;
            double poolCurrentVolume = volumeByFirstTube + volumeBySecondTube;

            if (poolCurrentVolume > poolCapacity)
            {
                Console.WriteLine($"For {howLongWorkerIsMissing} hours the pool overflows with {poolCurrentVolume - poolCapacity:0.0} liters.");
            }
            else
            {
                double poolFullness = (poolCurrentVolume / poolCapacity) * 100;

                double percentageVolumeFromFirstTube = (volumeByFirstTube / poolCurrentVolume) * 100;
                double percentageVolumeBySecondTube = (volumeBySecondTube / poolCurrentVolume) * 100;

                Console.WriteLine($"The pool is {Math.Floor(poolFullness)}% full. Pipe 1: {Math.Floor(percentageVolumeFromFirstTube)}%. Pipe 2: {Math.Floor(percentageVolumeBySecondTube)}%.");
            }
        }
    }
}
