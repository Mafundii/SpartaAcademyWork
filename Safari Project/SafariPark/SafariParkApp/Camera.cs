using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SafariParkApp
{
    public class Camera : IShootable
    {
        protected string _brand = "";
        protected string _user = "";
        protected string _target = "";

        public Camera(string brand)
        {
            _brand = brand;
        }

        public void SetTarget(Hunter target)
        {
            _target = target.FirstName;
        }

        public void SetUser(Hunter user)
        {
            _user = user.FirstName;
        }

        public (string, int) Shoot()
        {
            return ($"Say cheese, {_target}!!", 0);
        }

        public override string ToString()
        {
            return $"Camera: {_brand}";
        }
    }
}
