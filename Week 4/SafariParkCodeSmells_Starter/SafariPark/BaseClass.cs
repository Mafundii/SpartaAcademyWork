using System;
using System.Collections.Generic;
using System.Text;

namespace ClassesApp
{
    // A Class to represent a Person
    public class Person 
    {
        private string _firstName;
        private string _lastName;
        private int _age;
        private string _hobbies;
        private string _address;

        public Person() { }

        public Person(string fName, string lName, int houseeNumber = 0, string street = "", string town = "")
        {
            _firstName = fName;
            _lastName = lName;
            _address = new Address(houseeNumber, street, town);
        }

        public int Age
        {
            get { return _age; }
            set { if (value >= 0) _age = value; }
        }

        public string GetFullName()
        {
            return $"{_firstName} {_lastName}";
        }

        public string Move()
        {
            return "Walking along";
        }

        public string Move(int times)
        {
            return $"Walking along {times} times";
        }

        public override string ToString()
        {
            return $"{base.ToString()} Name: {_firstName} {_lastName} Age: {Age}. {GetAddress()}";
        }

        private string GetAddress()
        {
            return $"Address: {_houseNo} {_street}, {_town}";
        }
    }
}
