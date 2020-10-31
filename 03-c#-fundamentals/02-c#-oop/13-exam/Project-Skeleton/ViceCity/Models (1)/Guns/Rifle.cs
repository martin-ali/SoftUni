namespace ViceCity.Models.Guns
{
    using System;

    public class Rifle : Gun
    {
        private int bulletsInBarrel = 50;

        public Rifle(string name)
            : base(name, 50, 500)
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