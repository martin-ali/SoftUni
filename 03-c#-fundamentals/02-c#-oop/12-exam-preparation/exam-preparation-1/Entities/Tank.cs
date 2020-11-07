namespace MortalEngines.Entities
{
    using System;
    using MortalEngines.Entities.Contracts;

    public class Tank : BaseMachine, ITank
    {
        private const double DefaultHealthPoints = 100;

        private const double DefenseModeAttackNerf = 40;

        private const double DefenseModeDefenseBoost = 30;

        public Tank(string name, double attackPoints, double defensePoints)
            : base(name, attackPoints, defensePoints, DefaultHealthPoints)
        {
            this.ToggleDefenseMode();
        }

        public bool DefenseMode { get; private set; } = false;

        public void ToggleDefenseMode()
        {
            this.DefenseMode = !this.DefenseMode;

            if (this.DefenseMode)
            {
                this.AttackPoints -= DefenseModeAttackNerf;
                this.DefensePoints += DefenseModeDefenseBoost;
            }
            else
            {
                this.AttackPoints += DefenseModeAttackNerf;
                this.DefensePoints -= DefenseModeDefenseBoost;
            }
        }

        public override string ToString()
        {
            var defenseMode = this.DefenseMode ? "ON" : "OFF";
            return $"{base.ToString()}{Environment.NewLine} *Defense: {defenseMode}";
        }
    }
}