using System;

namespace DefiningClasses
{
    public class StartUp
    {
        public static void Main()
        {
            var pesho = new Person();
            pesho.Name = "Pesho";
            pesho.Age = 20;
            var gosho = new Person { Name = "Gosho", Age = 18 };
            // var stamat = new Person("Stamat", 43);
        }
    }
}