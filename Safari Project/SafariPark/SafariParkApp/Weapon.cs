using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SafariParkApp;

public abstract class Weapon : IShootable
{
    protected string _brand = "";
    protected int _damage = 5;
    protected int _critical = 2;
    protected string _message;
    protected string _user = "";
    private string _target = "";

    public Weapon() { }

    public Weapon(string brand)
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

    public virtual (string message, int finalDamage) Shoot()
    {
        var rand = new Random();
        int finalDamage = rand.Next(_damage - 1, _damage + 2);
        finalDamage *= rand.Next(0, 5) == 0 ? _critical : 1; 
        return ($"{_message}!! {_user} shot {_target} for {finalDamage} damage", finalDamage);
    }

    public override string ToString()
    {
        return $": {_brand}";
    }   
}
