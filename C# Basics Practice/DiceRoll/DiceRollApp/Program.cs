namespace DiceRollApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Random randNumber = new Random();
            

            int roll1;
            int roll2;
            int attempts = 0;

            roll1 = randNumber.Next(1, 6);
            roll2 = randNumber.Next(1, 6);

            Console.WriteLine("Press a button to roll");
            Console.ReadKey();
            Console.WriteLine($"You rolled a {roll1} and a {roll2}!");


            while (roll1 != roll2)
            {
                roll1 = randNumber.Next(1, 6);
                roll2 = randNumber.Next(1, 6);

                Console.WriteLine($"You rolled a {roll1} and a {roll2}!");
                Console.ReadKey();

                attempts++;

            }

            Console.WriteLine($"It took you {attempts} attempts to roll a two of a kind!");

            Console.ReadKey();


        }

    }
}