using System;
using System.Threading;
using System.Threading.Tasks;

namespace AysncCake
{
    class Program
    {
        public static async Task Main(string[] args)
        {
            Console.WriteLine("Welcome to my birthday party");
            await HaveAPartyAsync();
            Console.WriteLine("Thanks for a lovely party");
            Console.ReadLine();
        }

        private static async Task HaveAPartyAsync()
        {
            var name = "Cathy";
            var cakeTask = BakeCakeAsync();
            var foodTask = PrepareFoodAsync();
            PlayPartyGames();
            var food = await foodTask;
            Console.WriteLine($"{food}");
            await EatPartyDinnerAsync();
            OpenPresents();
            var cake = await cakeTask;
            Console.WriteLine($"Happy birthday, {name}, {cake}!!");
        }

        private static async Task<Food> PrepareFoodAsync()
        {
            Console.WriteLine("Food is being prepared");
            await Task.Delay(TimeSpan.FromSeconds(3));
            Console.WriteLine("Food is ready");
            return new Food();
        }

        private static async Task<Cake> BakeCakeAsync()
        {
            Console.WriteLine("Cake is in the oven");
            await Task.Delay(TimeSpan.FromSeconds(5));
            Console.WriteLine("Cake is done");
            return new Cake();
        }

        private static void PlayPartyGames()
        {
            Console.WriteLine("Starting games");
            Thread.Sleep(TimeSpan.FromSeconds(2));
            Console.WriteLine("Finishing Games");
        }

        private static void OpenPresents()
        {
            Console.WriteLine("Opening Presents");
            Thread.Sleep(TimeSpan.FromSeconds(1));
            Console.WriteLine("Finished Opening Presents");
        }

        private static async Task EatPartyDinnerAsync()
        {
            Console.WriteLine("Sit at the table and eat");
            await Task.Delay(TimeSpan.FromSeconds(1));
            Console.WriteLine("Finished eating. That was delicious!");
        }
    }

    public class Cake
    {
        public override string ToString()
        {
            return "Here's a cake";
        }
    }

    public class Food
    {
        public override string ToString()
        {
            return "Bon appetit!";
        }
    }
}
