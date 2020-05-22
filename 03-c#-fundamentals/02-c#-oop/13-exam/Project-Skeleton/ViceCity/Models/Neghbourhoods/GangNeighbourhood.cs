namespace ViceCity.Models.Neghbourhoods
{
    using System.Collections.Generic;
    using System.Linq;
    using ViceCity.Models.Guns.Contracts;
    using ViceCity.Models.Neghbourhoods.Contracts;
    using ViceCity.Models.Players.Contracts;

    public class GangNeighbourhood : INeighbourhood
    {
        public void Action(IPlayer mainPlayer, ICollection<IPlayer> civilPlayers)
        {
            foreach (var civillian in civilPlayers)
            {
                ShootAt(mainPlayer, civillian);
            }

            foreach (var civillian in civilPlayers.Where(p => p.IsAlive))
            {
                ShootAt(civillian, mainPlayer);
            }
        }

        private void ShootAt(IPlayer attacker, IPlayer defender)
        {
            try
            {
                if (attacker.GunRepository.Models.Count == 0 || attacker.IsAlive == false)
                {
                    return;
                }

                var guns = new Queue<IGun>(attacker.GunRepository.Models);
                var gun = guns.Dequeue();

                while (defender.IsAlive)
                {
                    if (gun.CanFire == false
                        && gun.TotalBullets == 0
                        && attacker.GunRepository.Models.Count == 0)
                    {
                        return;
                    }

                    if (gun.CanFire || gun.TotalBullets > 0)
                    {
                        defender.TakeLifePoints(gun.Fire());
                    }

                    if (gun.CanFire == false && gun.TotalBullets == 0)
                    {
                        gun = guns.Dequeue();
                    }
                }
            }
            catch (System.Exception)
            {
                return;
            }
        }
    }
}