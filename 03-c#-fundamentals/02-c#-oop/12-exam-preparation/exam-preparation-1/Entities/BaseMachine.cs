namespace MortalEngines.Entities
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using MortalEngines.Entities.Contracts;

    public abstract class BaseMachine : IMachine
    {
        private string name;

        private IPilot pilot;

        protected BaseMachine(string name, double attackPoints, double defensePoints, double healthPoints)
        {
            this.Name = name;
            this.AttackPoints = attackPoints;
            this.DefensePoints = defensePoints;
            this.HealthPoints = healthPoints;
        }

        public string Name
        {
            get => name;

            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException("Machine name cannot be null or empty.");
                }

                this.name = value;
            }
        }
        public IPilot Pilot
        {
            get => pilot;

            set
            {
                if (value == null)
                {
                    throw new NullReferenceException("Pilot cannot be null.");
                }

                this.pilot = value;
            }
        }

        public double HealthPoints { get; set; }

        public double AttackPoints { get; protected set; }

        public double DefensePoints { get; protected set; }

        public IList<string> Targets { get; } = new List<string>();

        public void Attack(IMachine target)
        {
            if (target == null)
            {
                throw new NullReferenceException("Target cannot be null");
            }

            var damage = this.AttackPoints - target.DefensePoints;
            target.HealthPoints -= damage;

            if (target.HealthPoints < 0)
            {
                target.HealthPoints = 0;
            }

            this.Targets.Add(target.Name);
        }

        public override string ToString()
        {
            var info = new StringBuilder();

            var targets = this.Targets.Any()
                            ? string.Join(',', this.Targets)
                            : "None";

            info
            .AppendLine($"- {this.Name}")
            .AppendLine($" *Type: {this.GetType().Name}")
            .AppendLine($" *Health: {this.HealthPoints:0.00}")
            .AppendLine($" *Attack: {this.AttackPoints:0.00}")
            .AppendLine($" *Defense: {this.DefensePoints:0.00}")
            .AppendLine($" *Targets: {targets}");

            return info.ToString().TrimEnd();
        }
    }
}