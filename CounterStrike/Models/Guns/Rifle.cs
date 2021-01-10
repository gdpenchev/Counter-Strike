using System;
using System.Collections.Generic;
using System.Text;

namespace CounterStrike.Models.Guns.Contracts
{
    public class Rifle : Gun
    {
        private const int BULLET_COUNT = 10;
        public Rifle(string name, int bulletsCount) : base(name, bulletsCount)
        {
        }

        public override int Fire()
        {
            if (this.BulletsCount <= 0)
            {
                return 0;
            }
            this.BulletsCount -= BULLET_COUNT;
            return BULLET_COUNT;
        }
    }
}
