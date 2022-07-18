using System.Collections.Generic;

namespace SafariParkApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            #region Notes
            //Person jon = new Person("Jon", "Crofts", 22);
            //Console.WriteLine(jon.GetFullName());
            //Console.WriteLine(jon.FullName);
            //Person charlie = new Person("Charlie");

            //Person peter = new Person();

            //Person dan = new Person("Dan", "Summerside") { Age = 100 };

            //Person laba = new Person { FirstName = "Laba", LastName = "Limbu", Age = 33 };
            //Console.WriteLine(laba.FullName);

            //var spartan = new Spartan { FullName = "Kai", Course = "C# SDET", PersonalId = 999 };

            //Hunter maks = new Hunter("Maks", "Hadys", "Sony") { Age = 10 };

            //Person nish = new Person("Nish", "Mandal") { Age = 30 };

            //Console.WriteLine(maks.GetHashCode());
            //Console.WriteLine(1.GetHashCode());
            //Console.WriteLine(1.GetHashCode());

            //Console.WriteLine(maks.GetType());

            //Console.WriteLine(maks.ToString());
            #endregion
            #region More Notes
            //Airplane a = new Airplane(200, 100, "JetsRUs") { NumPassengers = 150 };
            //a.Ascend(500);
            //Console.WriteLine(a.Move(3));
            //Console.WriteLine(a);
            //a.Descend(200);
            //Console.WriteLine(a.Move());
            //a.Move();
            //Console.WriteLine(a);

            //var ellis = new Hunter("Ellis", "Witten", new Camera("Nikon")) { Age = 21 };
            //var plane = new Airplane(400, 200, "Virgin");
            //var vehicle = new Vehicle(20, 20);
            //var kenny = new Person("Kenny", "Harvey") { Age = 22 };
            ////
            //var cam = new Camera("Panasonic");

            //List<IMovable> objects = new List<IMovable>() { ellis, vehicle, plane, kenny };

            //foreach (var obj in objects)
            //{
            //    //Console.WriteLine(obj);
            //    Console.WriteLine(obj.Move(3));
            //}

            //List<IShootable> weapons = new List<IShootable>()
            //{
            //    new WaterPistol("Nerf"),
            //    new LaserGun("General Atomics"),
            //    ellis,
            //    cam
            //};
            //
            //foreach (IShootable weapon in weapons)
            //    Console.WriteLine(weapon.Shoot());
            #endregion

            //ShootyGame();

            #region List Exercise

            List<int> list = new List<int>() { 5, 4, 3, 9, 0 };

            list.Add(8);

            list.Sort((a, b) => a.CompareTo(b));


            // Queues

            var myQueue = new Queue<Person>();
            myQueue.Enqueue(new Person("Peter", "Parker"));
            
            myQueue.Enqueue(new Person ("David", "Smith"));

            // Stack
            // Last in first out

            var stack = new Stack<int>();
            int[] nums = new int[] { 1, 2, 3, 4, 5, 6 };
            int[] numsReversed = new int[nums.Length];

            foreach (var num in nums)
            {
                stack.Push(num);
            }

            for (int i = 0; i < numsReversed.Length; i++)
            {
                numsReversed[i] = stack.Pop();
            }

            // Hashsets

            var peopleSet = new HashSet<Person>
            {
                new Person ("David", "Smith"), new Person("Peter", "Parker")
            };


            var morePeople = new HashSet<Person> { new Person("Cathy", "French"), new Person("Jasmine", "Smith"), new Person("Peter", "Parker") };

            peopleSet.IntersectWith(morePeople);


            var vehicleSet = new HashSet<Vehicle>
            {
                new Vehicle() { NumPassengers = 3, Speed = 2},
                
            };


            // Dictionaries



            #endregion


        }

        public static void ShootyGame()
        {
            bool running = true;

            (Hunter player, Hunter enemy) hunters = FirstRun();
            Hunter player = hunters.player;
            Hunter enemy = hunters.enemy;

            while (running)
            {
                Update(player, enemy);
                running = Input(player, enemy);
                if (enemy.health <= 0)
                {
                    Console.WriteLine($"GAME OVER\n{player.FullName} Wins!");
                    running = false;
                }
                else if (player.health <= 0)
                {
                    Console.WriteLine($"GAME OVER\n{enemy.FullName} Wins!");
                    running = false;
                }
            }
            Console.WriteLine("Thanks for playing!");
        }

        public static void Update(Hunter player, Hunter enemy)
        {
            (string message, int damage) result = enemy.Shoot();
            Console.WriteLine(result.message);

            player.health -= result.damage;
        }

        public static bool Input(Hunter player, Hunter enemy)
        {
            Console.Write($"------------\n\tPlayer Health: {player.health}\n\tType 'shoot' to shoot, or 'quit' to quit\n > ");
            string input = Console.ReadLine().ToLower();

            if (input == "shoot")
            {
                (string message, int damage) result = player.Shoot();
                Console.WriteLine(result.message);

                enemy.health -= result.damage;
            }
            else if (input == "quit")
                return false;
            
            return true;
        }

        public static (Hunter, Hunter) FirstRun()
        {
            Console.Write("Welcome to the Game!\nPlease enter a name:\n First Name: ");
            string firstName = Console.ReadLine();
            Console.Write(" Last Name: ");
            string lastName = Console.ReadLine();

            List<IShootable> weapons = new List<IShootable>()
            {
                new WaterPistol("Nerf", 1, 2),
                new LaserGun("General Atomics", 2, 2),
                new Camera("Nikon")         
            };

            Console.WriteLine("Please choose a weapon (Type the corresponding number)");
            for (int i = 0; i < weapons.Count; i++)
                Console.WriteLine($"{i + 1}. {weapons[i]}");

            int index = 0;
            bool getWeap = false;

            while (!getWeap)
            {
                if (!int.TryParse(Console.ReadLine(), out index))
                    Console.WriteLine("Please enter an integer");
                else
                {
                    getWeap = index >= 1 && index <= weapons.Count;
                    if (!getWeap)
                        Console.WriteLine($"Please enter an integer between 1 and {weapons.Count}");
                }
            }

            Console.WriteLine($"Name: {firstName} {lastName}, Selected Weapon: {weapons[index - 1]}");

            Hunter player = new(firstName, lastName, weapons[index - 1]);

            var rand = new Random();
            Hunter enemy = new("Nish", "Mandal", weapons[rand.Next(0, weapons.Count)]);

            player.Shooter.SetTarget(enemy);
            enemy.Shooter.SetTarget(player);

            return (player, enemy);
        }
    }
}