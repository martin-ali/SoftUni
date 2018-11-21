namespace _12_google
{
    public class Workplace
    {
        public Workplace(string name, string department, decimal salary)
        {
            this.Name = name;
            this.Department = department;
            this.Salary = salary;
        }

        public string Name { get; set; }

        public string Department { get; set; }

        public decimal Salary { get; set; }

        public override string ToString() => $"{this.Name} {this.Department} {this.Salary:0.00}";
    }
}