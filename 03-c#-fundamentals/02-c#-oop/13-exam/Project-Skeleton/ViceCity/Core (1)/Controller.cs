namespace ViceCity.Core
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using ViceCity.Core.Contracts;
    using ViceCity.Models.Guns;
    using ViceCity.Models.Guns.Contracts;
    using ViceCity.Models.Neghbourhoods;
    using ViceCity.Models.Players;
    using ViceCity.Models.Players.Contracts;

    public class Controller : IController
    {
        private Queue<IGun> guns = new Queue<IGun>();
        private List<IPlayer> civilPlayers = new List<IPlayer>();
        private IPlayer mainPlayer = new MainPlayer();

        public string AddGun(string type, string name)
        {
            switch (type)
            {
                case "Pistol":
                    {
                        this.guns.Enqueue(new Pistol(name));
                        break;
                    }

                case "Rifle":
                    {
                        this.guns.Enqueue(new Rifle(name));
                        break;
                    }

                default: return "Invalid gun type!";
            }

            return $"Successfully added {name} of type: {type}";
        }

        public string AddGunToPlayer(string name)
        {
            if (this.guns.Any() == false)
            {
                return "There are no guns in the queue!";
            }

            var gun = guns.Peek();

            if (name == "Vercetti")
            {
                this.mainPlayer.GunRepository.Add(gun);

                this.guns.Dequeue();
                return $"Successfully added {gun.Name} to the Main Player: Tommy Vercetti";
            }

            var player = this.civilPlayers.Find(p => p.Name == name);
            if (player == null)
            {
                return "Civil player with that name doesn't exists!";
            }

            player.GunRepository.Add(gun);
            this.guns.Dequeue();

            return $"Successfully added {gun.Name} to the Civil Player: {player.Name}";
        }

        public string AddPlayer(string name)
        {
            var player = new CivilPlayer(name);
            this.civilPlayers.Add(player);

            return $"Successfully added civil player: {name}!";
        }

        public string Fight()
        {
            var neighbourhood = new GangNeighbourhood();
            neighbourhood.Action(this.mainPlayer, this.civilPlayers);

            if (this.mainPlayer.LifePoints == 100 && this.civilPlayers.All(p => p.LifePoints == 50))
            {
                return "Everything is okay!";
            }
            else
            {
                return "A fight happened:" + Environment.NewLine
                    + $"Tommy live points: {this.mainPlayer.LifePoints}!" + Environment.NewLine
                    + $"Tommy has killed: {this.civilPlayers.Count(p => !p.IsAlive)} players!" + Environment.NewLine
                    + $"Left Civil Players: {this.civilPlayers.Count(p => p.IsAlive)}!";
            }
        }
    }
}