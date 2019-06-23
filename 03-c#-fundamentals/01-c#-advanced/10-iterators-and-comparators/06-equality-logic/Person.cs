using System;

namespace _06_equality_logic
{
    public class Person : IComparable<Person>
    {
        public Person(string name, int age)
        {
            this.Name = name;
            this.Age = age;
        }

        public string Name { get; set; }

        public int Age { get; set; }

        public static Person Parse(string data)
        {
            var parameters = data.Split();
            var name = parameters[0];
            var age = int.Parse(parameters[1]);

            return new Person(name, age);
        }

        public int CompareTo(Person other)
        {
            if (this.Name != other.Name)
            {
                return this.Name.CompareTo(other.Name);
            }

            if (this.Age != other.Age)
            {
                return this.Age.CompareTo(other.Age);
            }

            return 0;
        }

        public override bool Equals(object obj)
        {
            var otherPerson = (Person)obj;

            return this.CompareTo(otherPerson) == 0;
        }

        public override int GetHashCode()
        {
            return this.Name.GetHashCode() + this.Age;
        }
    }
}