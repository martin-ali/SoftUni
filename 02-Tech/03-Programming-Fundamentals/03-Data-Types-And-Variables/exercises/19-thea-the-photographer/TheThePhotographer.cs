using System;

namespace _19_thea_the_photographer
{
    class TheThePhotographer
    {
        static void Main()
        {
            long numberOfPicturesTaken = long.Parse(Console.ReadLine());
            long filterTime = long.Parse(Console.ReadLine());
            double percentageOfGoodPictures = long.Parse(Console.ReadLine()) / 100.0;
            long uploadTimePerFilteredPicture = long.Parse(Console.ReadLine());

            var timeTakenToFilter = numberOfPicturesTaken * filterTime;
            var filteredImages = Math.Ceiling(numberOfPicturesTaken * percentageOfGoodPictures);
            var timeTakenToUploadPictures = filteredImages * uploadTimePerFilteredPicture;

            long secondsTaken = (long)(timeTakenToFilter + timeTakenToUploadPictures);
            var timeTaken = TimeSpan.FromSeconds(secondsTaken);
            Console.WriteLine(timeTaken.ToString("d\\:hh\\:mm\\:ss"));
        }
    }
}
