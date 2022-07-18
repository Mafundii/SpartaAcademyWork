using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SafariParkApp
{
    public class LaserGun : Weapon
    {
        public LaserGun(string brand, int damage, int critical) : base(brand)
        {
            _damage = damage;
            _critical = critical;
            _message = "Pew";
        }

        public override string ToString()
        {
            return "Laser Gun" + base.ToString();
        }
    }
}
