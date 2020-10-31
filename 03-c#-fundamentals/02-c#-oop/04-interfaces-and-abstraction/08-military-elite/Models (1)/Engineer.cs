namespace _08_military_elite.Models
{
    using System.Collections.Generic;
    using System.Text;
    using _08_military_elite.Interfaces;

    public class Engineer : SpecialisedSoldier, IEngineer
    {
        public Engineer(string id, string firstName, string lastName, decimal salary, string corps, List<IRepair> repairs)
            : base(id, firstName, lastName, salary, corps)
        {
            this.Repairs = repairs;
        }

        public List<IRepair> Repairs { get; }

        public override string ToString()
        {
            var information = new StringBuilder();

            information.AppendLine($"{base.ToString()}");
            information.AppendLine($"Corps: {this.Corps}");
            information.AppendLine("Repairs:");
            foreach (var repair in this.Repairs)
            {
                information.AppendLine($"  {repair.ToString()}");
            }

            return information.ToString().TrimEnd();
        }
    }
}