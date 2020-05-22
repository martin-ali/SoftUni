namespace Animals
{
    using System;
    using System.Text;

    public abstract class Animal
    {
        public Animal(string name, int age, string gender)
        {
            if (name == null
                || string.IsNullOrWhiteSpace(name)
                || gender == null
                || age <= 0)
            {
                throw new ArgumentException("Invalid input!");
            }

            this.Name = name;
            this.Age = age;
            this.Gender = gender;
        }

        public string Name { get; private set; }

        public int Age { get; private set; }

        public string Gender { get; private set; }

        public virtual string ProduceSound()
        {
            return "Sound!";
        }

        public override string ToString()
        {
            var profile = new StringBuilder();

            profile.AppendLine($"{this.GetType().Name}");
            profile.AppendLine($"{this.Name} {this.Age} {this.Gender}");
            profile.AppendLine($"{this.ProduceSound()}");

            return profile.ToString();
        }
    }
}