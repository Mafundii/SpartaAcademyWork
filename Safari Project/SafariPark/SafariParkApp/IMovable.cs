using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SafariParkApp
{
    public interface IMovable
    {
        // Properties and methods - public
        // Method is also abstract as it exists inside an interface
        string Move();
        string Move(int times);

    }
}
