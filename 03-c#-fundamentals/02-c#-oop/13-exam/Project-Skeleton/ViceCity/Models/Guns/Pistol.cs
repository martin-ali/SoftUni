using System;

namespace ViceCity.Models.Guns
{
    public class Pistol : Gun
    {
        private int bulletsInBarrel = 10;

        public Pistol(string name)
            : base(name, 10, 100)
        {
        }

        public override int Fire()
        {
            if (this.CanFire == false)
            {
                if (this.TotalBullets > 0)
                {
                    var bulletsTaken = Math.Min(this.TotalBullets, this.BulletsPerBarrel);

                    this.bulletsInBarrel += bulletsTaken;
                    this.TotalBullets -= bulletsTaken;
                }
            }

            if (this.CanFire)
            {
                var bulletsShot = Math.Min(this.bulletsInBarrel, 5);

                this.bulletsInBarrel -= bulletsShot;

                return bulletsShot;
            }

            return 0;
        }
    }
}