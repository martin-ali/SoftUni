namespace _08_military_elite.Models
{
    using _08_military_elite.Interfaces;

    public class Private : Soldier, IPrivate
    {
        // private decimal salary;

        public Private(string id, string firstName, string lastName, decimal salary)
            : base(id, firstName, lastName)
        {
            this.Salary = salary;
        }

        public decimal Salary { get; }

        public override string ToString()
        {
            return $"{base.ToString()} Salary: {this.Salary:0.00}";
        }
    }
}