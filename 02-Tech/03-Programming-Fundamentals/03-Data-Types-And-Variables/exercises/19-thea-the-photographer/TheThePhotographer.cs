using System;

namespace _19_thea_the_photographer
{
    class TheThePhotographer
    {
        static void Main()
        {
            var numberOfPicturesTaken = long.Parse(Console.ReadLine());
            var filterTime = long.Parse(Console.ReadLine());
            var percentageOfGoodPictures = long.Parse(Console.ReadLine()) / 100.0;
            var uploadTimePerFilteredPicture = long.Parse(Console.ReadLine());

            var timeTakenToFilter = numberOfPicturesTaken * filterTime;
            var numberOfFilteredImages = Math.Ceiling(numberOfPicturesTaken * percentageOfGoodPictures);
            var timeTakenToUploadPictures = numberOfFilteredImages * uploadTimePerFilteredPicture;

            var secondsTaken = timeTakenToFilter + timeTakenToUploadPictures;
            var totalTimeTaken = TimeSpan.FromSeconds(secondsTaken);
            Console.WriteLine(totalTimeTaken.ToString("d\\:hh\\:mm\\:ss"));
        }
    }
}
