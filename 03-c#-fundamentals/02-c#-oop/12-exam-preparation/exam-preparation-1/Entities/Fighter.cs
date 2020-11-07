namespace MortalEngines.Entities
{
    using System;
    using MortalEngines.Entities.Contracts;

    public class Fighter : BaseMachine, IFighter
    {
        private const double DefaultHealthPoints = 200;

        private const double AggressiveModeAttackBoost = 50;

        private const double AggressiveModeDefenseNerf = 25;

        public Fighter(string name, double attackPoints, double defensePoints)
            : base(name, attackPoints, defensePoints, DefaultHealthPoints)
        {
            this.ToggleAggressiveMode();
        }

        public bool AggressiveMode { get; private set; } = false;

        public void ToggleAggressiveMode()
        {
            this.AggressiveMode = !this.AggressiveMode;

            if (this.AggressiveMode)
            {
                this.AttackPoints += AggressiveModeAttackBoost;
                this.DefensePoints -= AggressiveModeDefenseNerf;
            }
            else
            {
                this.AttackPoints -= AggressiveModeAttackBoost;
                this.DefensePoints += AggressiveModeDefenseNerf;
            }
        }

        public override string ToString()
        {
            var aggressiveMode = this.AggressiveMode ? "ON" : "OFF";
            return $"{base.ToString()}{Environment.NewLine} *Aggressive: {aggressiveMode}";
        }
    }
}