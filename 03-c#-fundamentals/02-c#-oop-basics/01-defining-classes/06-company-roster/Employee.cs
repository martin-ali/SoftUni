namespace DefiningClasses
{
    public class Employee
    {
        public Employee(string name, decimal salary, string position, string department)
        {
            this.Name = name;
            this.Salary = salary;
            this.Position = position;
            this.Department = department;
            this.Email = "n/a";
            this.Age = -1;
        }

        public string Name { get; private set; }

        public decimal Salary { get; private set; }

        public string Position { get; private set; }

        public string Department { get; private set; }

        public string Email { get; set; }

        public int Age { get; set; }
    }
}