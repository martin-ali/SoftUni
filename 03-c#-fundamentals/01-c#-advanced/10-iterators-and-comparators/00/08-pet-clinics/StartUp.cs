using System;

namespace _08_pet_clinics
{
    class StartUp
    {
        static void Main()
        {
            var clinicManager = new PetClinicManager();
            var commandCount = int.Parse(Console.ReadLine());

            for (int i = 0; i < commandCount; i++)
            {
                try
                {
                    var result = clinicManager.ParseCommand(Console.ReadLine());
                    Console.WriteLine(result);
                }
                catch (Exception exception)
                {
                    Console.WriteLine(exception.Message);
                }
            }
        }
    }
}
/*

12
Create Clinic Rezovo 5
Create Pet Sharo1 2 Dog
Create Pet Sharo2 2 Dog
Create Pet Sharo3 2 Dog
Create Pet Sharo4 2 Dog
Create Pet Sharo5 2 Dog
Add Sharo1 Rezovo
Add Sharo2 Rezovo
Add Sharo3 Rezovo
Add Sharo4 Rezovo
Add Sharo5 Rezovo
HasEmptyRooms Rezovo

*/
