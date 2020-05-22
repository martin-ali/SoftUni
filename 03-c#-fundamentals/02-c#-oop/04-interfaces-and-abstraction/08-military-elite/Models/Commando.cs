namespace _08_military_elite.Models
{
    using System.Collections.Generic;
    using System.Text;
    using _08_military_elite.Interfaces;

    public class Commando : SpecialisedSoldier, ICommando
    {
        public Commando(string id, string firstName, string lastName, decimal salary, string corps, ISet<IMission> missions)
            : base(id, firstName, lastName, salary, corps)
        {
            this.Missions = missions;
        }

        public ISet<IMission> Missions { get; }

        public override string ToString()
        {
            var information = new StringBuilder();

            information.AppendLine($"{base.ToString()}");
            information.AppendLine($"Corps: {this.Corps}");
            information.AppendLine("Missions:");
            foreach (var mission in this.Missions)
            {
                information.AppendLine($"  {mission.ToString()}");
            }

            return information.ToString().TrimEnd();
        }
    }
}