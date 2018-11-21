using System.Collections.Generic;

namespace _13_family_tree
{
    public class Person
    {
        public Person() { }

        public Person(string name, string birthDate)
        {
            this.Name = name;
            this.BirthDate = birthDate;
        }

        public string Name { get; set; }

        public string BirthDate { get; set; }

        public List<Person> Parents { get; set; } = new List<Person>();

        public List<Person> Children { get; set; } = new List<Person>();

        public override string ToString()
        {
            return $"{this.Name ?? string.Empty} {this.BirthDate ?? string.Empty}";
        }
    }
}