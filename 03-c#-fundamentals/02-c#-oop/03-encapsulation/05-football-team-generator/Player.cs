namespace _05_football_team_generator
{
    using System;

    public class Player
    {
        private int endurance;

        private int sprint;

        private int shooting;

        private int passing;

        private int dribble;

        public Player(string name, int endurance, int sprint, int dribble, int passing, int shooting)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentException(ErrorMessages.NameEmpty);
            }

            this.Name = name;
            this.Endurance = endurance;
            this.Sprint = sprint;
            this.Dribble = dribble;
            this.Passing = passing;
            this.Shooting = shooting;
        }

        public string Name { get; }

        public int Endurance
        {
            get => this.endurance;

            private set
            {
                this.ThrowIfStatIsInvalid(nameof(this.Endurance), value);

                this.endurance = value;
            }
        }

        public int Sprint
        {
            get => this.sprint;

            private set
            {
                this.ThrowIfStatIsInvalid(nameof(this.Sprint), value);

                this.sprint = value;
            }
        }

        public int Dribble
        {
            get => dribble;

            private set
            {
                this.ThrowIfStatIsInvalid(nameof(this.Dribble), value);

                dribble = value;
            }
        }

        public int Passing
        {
            get => passing;

            private set
            {
                this.ThrowIfStatIsInvalid(nameof(this.Passing), value);

                passing = value;
            }
        }

        public int Shooting
        {
            get => shooting;

            private set
            {
                this.ThrowIfStatIsInvalid(nameof(this.Shooting), value);

                shooting = value;
            }
        }

        public double Skill
        {
            get
            {
                var skillsAverage = (this.Endurance
                                    + this.Sprint
                                    + this.Dribble
                                    + this.Passing
                                    + this.Shooting) / 5d;

                return skillsAverage;
            }
        }

        private void ThrowIfStatIsInvalid(string stat, int value)
        {
            var statIsValid = 0 <= value && value <= 100;
            if (statIsValid == false)
            {
                throw new ArgumentException($"{stat} should be between 0 and 100.");
            }
        }
    }
}