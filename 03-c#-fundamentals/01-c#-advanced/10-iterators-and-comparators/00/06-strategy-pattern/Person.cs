namespace _06_strategy_pattern
{
    public class Person
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

        public override string ToString()
        {
            return $"{this.Name} {this.Age}";
        }
    }
}