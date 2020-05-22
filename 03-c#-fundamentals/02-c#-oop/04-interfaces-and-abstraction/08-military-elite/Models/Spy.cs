namespace _08_military_elite.Models
{
    using System;
    using System.Text;
    using _08_military_elite.Interfaces;

    public class Spy : Soldier, ISpy
    {
        public Spy(string id, string firstName, string lastName, int codeNumber) : base(id, firstName, lastName)
        {
            this.CodeNumber = codeNumber;
        }

        public int CodeNumber { get; }

        public override string ToString()
        {
            var information = new StringBuilder();

            information.AppendLine($"{base.ToString()}");
            information.AppendLine($"Code Number: {this.CodeNumber}");

            return information.ToString().TrimEnd();
        }
    }
}