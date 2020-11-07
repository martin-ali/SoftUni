namespace MortalEngines.Entities
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using MortalEngines.Entities.Contracts;

    public class Pilot : IPilot
    {
        private string name;

        private IList<IMachine> machines = new List<IMachine>();

        public Pilot(string name)
        {
            this.Name = name;
        }

        public string Name
        {
            get => name;

            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException("Pilot name cannot be null or empty string.");
                }

                this.name = value;
            }
        }

        public void AddMachine(IMachine machine)
        {
            if (machine == null)
            {
                throw new NullReferenceException("Null machine cannot be added to the pilot.");
            }

            this.machines.Add(machine);
        }

        public string Report()
        {
            var report = new StringBuilder();

            report.AppendLine($"{this.Name} - {this.machines.Count} machines");
            foreach (var machine in this.machines)
            {
                report.AppendLine(machine.ToString());
            }

            return report.ToString().TrimEnd();

        }
    }
}