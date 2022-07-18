using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SafariParkApp
{
    public class Hunter : Person
    {
        public int health = 25;
        public Hunter(string fName, string lName, IShootable shooter) : base(fName, lName)
        {
            Shooter = shooter;
            Shooter.SetUser(this);
        }

        public IShootable Shooter { get; set; }

        public (string message, int finalDamage) Shoot()
        {
            return Shooter.Shoot();
        }
        
        


    }

}
