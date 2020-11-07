namespace ViceCity.Models.Players
{
    using System;
    using ViceCity.Models.Guns.Contracts;
    using ViceCity.Models.Players.Contracts;
    using ViceCity.Repositories;
    using ViceCity.Repositories.Contracts;

    public abstract class Player : IPlayer
    {
        private int lifePoints;
        private string name;

        public Player(string name, int lifePoints)
        {
            this.Name = name;
            this.LifePoints = lifePoints;
        }

        public string Name
        {
            get => this.name;

            protected set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException("Player's name cannot be null or a whitespace!");
                }

                this.name = value;
            }
        }

        public bool IsAlive { get => this.LifePoints > 0; }

        public IRepository<IGun> GunRepository { get; } = new GunRepository();

        public int LifePoints
        {
            get => this.lifePoints;

            protected set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Player life points cannot be below zero!");
                }

                this.lifePoints = value;
            }
        }

        public void TakeLifePoints(int points)
        {
            var life = this.LifePoints - points;

            if (life < 0)
            {
                life = 0;
            }

            this.LifePoints = life;
        }
    }
}