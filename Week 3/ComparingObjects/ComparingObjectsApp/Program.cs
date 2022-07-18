namespace ComparingObjectsApp
{
    public class Program
    {
        static void Main(string[] args)
        {
            //var nish = new Person("Nish", "Mandal") { Age = 22 };
            //var david = nish;
            //var tom = new Person("Nish", "Mandal") { Age = 22 };
            //Console.WriteLine(tom.Equals(nish));
            var bob = new Person("Bob", "The Builder") { Age = 25};

            var people = new List<Person>
            {
                new Person("Cath", "Kidson") { Age = 30 },
                new Person("Maks", "Hadys"),
                new Person("Tom", "Holland") { Age = 22 },
                new Person("Nish", "Mandal"),

            };

            bool hasBob = people.Contains(bob);
            Console.WriteLine(hasBob);

            people.ForEach(x => Console.WriteLine(x.GetFullName()));
            people.OrderBy(x => x.Age);
            Console.WriteLine();
            people.ForEach(x => Console.WriteLine(x.GetFullName()));


        }
    }

    public class Person : IEquatable<Person?>, IComparable<Person>

    {
        private string _firstName;
        private string _lastName;
        private int _age;
        public Person() { }
        public Person(string fName, string lName)
        {
            _firstName = fName;
            _lastName = lName;
        }

        public int Age
        {
            get { return _age; }
            set { if (value >= 0) _age = value; }
        }

        public int CompareTo(Person? other)
        {
            if (other == null)
            {
                return 1;
            }
            else if (this._lastName != other._lastName)
            {
                return this._lastName.CompareTo(other._lastName);
            }
            else if (this._firstName != other._firstName)
            {
                return this._firstName.CompareTo(other._firstName);
            }
            else 
            {
                return this.Age.CompareTo(other.Age);
            }
        }

        public override bool Equals(object? obj)
        {
            return Equals(obj as Person);
        }

        public bool Equals(Person? other)
        {
            return other is not null &&
                   _firstName == other._firstName &&
                   _lastName == other._lastName &&
                   _age == other._age &&
                   Age == other.Age;
        }

        public string GetFullName()
        {
            return $"{_firstName} {_lastName}";
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(_firstName, _lastName, _age, Age);
        }

        public static bool operator ==(Person? left, Person? right)
        {
            return EqualityComparer<Person>.Default.Equals(left, right);
        }

        public static bool operator !=(Person? left, Person? right)
        {
            return !(left == right);
        }
    }


}