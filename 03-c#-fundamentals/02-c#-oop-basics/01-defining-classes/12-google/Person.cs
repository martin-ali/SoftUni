using System;
using System.Collections.Generic;

namespace _12_google
{
    public class Person
    {
        public Person(string name)
        {
            this.Name = name;
        }

        public string Name { get; set; }

        public Workplace Company { get; set; }

        public Car Car { get; set; }

        public List<Relative> Parents { get; set; } = new List<Relative>();

        public List<Relative> Children { get; set; } = new List<Relative>();

        public List<Pokemon> Pokemon { get; set; } = new List<Pokemon>();

        public override string ToString()
        {
            var text = new List<string>()
            {
                $"{this.Name}"
            };

            text.Add($"Company:");
            if (this.Company != null)
            {
                text.Add(this.Company.ToString());
            }

            text.Add($"Car:");
            if (this.Car != null)
            {
                text.Add(this.Car.ToString());
            }

            text.Add("Pokemon:");
            foreach (var pokemon in this.Pokemon)
            {
                text.Add(pokemon.ToString());
            }

            text.Add("Parents:");
            foreach (var parent in this.Parents)
            {
                text.Add(parent.ToString());
            }

            text.Add("Children:");
            foreach (var child in this.Children)
            {
                text.Add(child.ToString());
            }

            return string.Join(Environment.NewLine, text);
        }
    }
}