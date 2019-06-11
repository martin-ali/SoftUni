using System;

namespace DefiningClasses
{
    public class StartUp
    {
        static void Main()
        {
            var firstPerson = new Person("Pesho", 20);
            var secondPerson = new Person("Gosho");
            var thirdPerson = new Person(43);
        }
    }
}
