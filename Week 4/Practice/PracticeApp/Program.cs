namespace PracticeApp
{
    public class Program
    {
        static void Main(string[] args)
        {
            Person maks = new("Maks");
            maks.SetFirstName("Rambo");

            Person david = new("David");
            david.LastName = "Rambo";

            var peopleDict = new Dictionary<string, Person>();

            peopleDict.Add("Maks", maks);
            peopleDict.Add("David", david);
            peopleDict.Add("Teacher", new Person("Nish"));

            Console.WriteLine(peopleDict["Teacher"].FirstName + " " + peopleDict["Teacher"].LastName );

            foreach (var person in peopleDict.Values)
            {
                Console.WriteLine(person.FirstName);
            }
            foreach(var key in peopleDict.Keys)
            {
                Console.WriteLine(key);
            }



        }
    }

    public class Person
    {
        private string _firstName;

        public string FirstName
        {
            get => _firstName;
            set
            {
                foreach (char letter in value.ToLower())
                {
                    if (letter < 'a' || letter > 'z')
                    {
                        return;
                    }
                }

                _firstName = value;
            }
        }       
        
        // No need for for initialising a private field when not using custom get or set methods.
        public string LastName { get; set; }  


        public Person(string firstName)
        {
            _firstName = firstName;
        }
        
        public string GetFirstName()
        {
            return _firstName;
        }

        public void SetFirstName(string newFirstName)
        {
            foreach (char letter in newFirstName.ToLower())
            {
                if (letter < 'a' || letter > 'z')
                {
                    return;
                }
            }

            _firstName = newFirstName;

        }

    }

}