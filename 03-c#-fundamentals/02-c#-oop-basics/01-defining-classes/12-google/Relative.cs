using System;

namespace _12_google
{
    public class Relative
    {
        public Relative(string name, string birthday)
        {
            this.Name = name;
            this.Birthday = birthday;
        }

        public string Name { get; set; }

        public string Birthday { get; set; }

        public override string ToString() => $"{this.Name} {this.Birthday}";
    }
}