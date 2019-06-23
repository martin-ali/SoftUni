using System;

namespace _05_comparing_objects
{
    public class Person : IComparable<Person>
    {
        public Person(string name, int age, string town)
        {
            this.Name = name;
            this.Age = age;
            this.Town = town;
        }

        public string Name { get; set; }

        public int Age { get; set; }

        public string Town { get; set; }

        public static Person Parse(string data)
        {
            var parameters = data.Split();
            var name = parameters[0];
            var age = int.Parse(parameters[1]);
            var town = parameters[2];

            return new Person(name, age, town);
        }

        public int CompareTo(Person other)
        {
            if (this.Name != other.Name)
            {
                return this.Name.CompareTo(other.Name);
            }
            else if (this.Age != other.Age)
            {
                return this.Age.CompareTo(other.Age);
            }
            else if (this.Town != other.Town)
            {
                return this.Town.CompareTo(other.Town);
            }

            return 0;
        }
    }
}