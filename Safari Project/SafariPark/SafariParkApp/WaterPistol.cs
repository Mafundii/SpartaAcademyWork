using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SafariParkApp;

public class WaterPistol : Weapon
{
    public WaterPistol(string brand, int damage, int critical) : base(brand)
    {
        _damage = damage;
        _critical = critical;
        _message = "Squirt";
    }

    public override string ToString()
    {
        return "Water Pistol" + base.ToString();
    }
}

