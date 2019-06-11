using System;

namespace DefiningClasses
{
    public class StartUp
    {
        static void Main()
        {
            var firstPerson = new Person { Name = "Pesho", Age = 20 };

            var secondPerson = new Person("Gosho", 18);

            var thirdPerson = new Person();
            thirdPerson.Name = "Stamat";
            thirdPerson.Age = 43;
        }
    }
}
