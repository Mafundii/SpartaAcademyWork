using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SafariParkApp
{
    public interface IShootable
    {
        (string message, int finalDamage) Shoot();
        void SetTarget(Hunter target);
        void SetUser(Hunter user);
    }
}
