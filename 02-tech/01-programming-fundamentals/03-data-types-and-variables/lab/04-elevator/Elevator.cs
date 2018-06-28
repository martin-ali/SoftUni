using System;

namespace _04_elevator
{
    class Elevator
    {
        static void Main()
        {
            int numberOfPeople = int.Parse(Console.ReadLine());
            int capacity = int.Parse(Console.ReadLine());

            var numberOfCourses = Math.Ceiling((double)numberOfPeople / capacity);
            Console.WriteLine(numberOfCourses);
        }
    }
}
