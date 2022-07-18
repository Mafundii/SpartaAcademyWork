using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SafariParkApp
{
    public class Person : IMovable
    {
        private const int numberOfFingers = 12;

        private readonly string _hairColour;

        public string FirstName { get; set; }
        public string LastName { get; set; }

        //public int Age { get; set; }
        ////This is what happens under the hood
        private int _age;
        public int Age
        {
            get { return _age; }
            set { _age = value < 0 ? throw new ArgumentException() : value; }
            
        }

        public Person(string firstName, string lastName, int age, string hairColour)
        {        
            FirstName = firstName;
            LastName = lastName;
            Age = age;
            _hairColour = hairColour;
        }

        public Person(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;
        }

        public Person()
        {

        }

        //Making full name a propert
        public string FullName => $"{FirstName} {LastName}";

        //Virtual of override in signature
        //Derived classes can override that method
        public override sealed string ToString()
        {
            return $"{base.ToString()}";
        }

        public string Move()
        {
            return $"Walking along";
        }

        public string Move(int times)
        {
            return $"Walking along {times} times";
        }
    }
}