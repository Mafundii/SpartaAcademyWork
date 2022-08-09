using System.Diagnostics;

namespace LoggingStreamingAndEncoding
{
    internal class Program
    {

        private static string _currentDirectory = Directory.GetCurrentDirectory();
        private static string _path = Path.Combine(_currentDirectory, @"..\..\..\");
        static void Main(string[] args)
        {
            #region File Operations
            //Console.WriteLine("What is your name?");
            //var name = Console.ReadLine();
            //Console.WriteLine($"Name: {name}");

            //string currentDirectory = Directory.GetCurrentDirectory();
            //var path = Path.Combine(currentDirectory, @"..\..\..\");
            //var text = "Hello World!";
            //File.WriteAllText(path + "Hello.txt", text);

            //string content = File.ReadAllText(path + "Hello.txt");
            //Console.WriteLine(content);

            //string[] lines = { "And after all", "You're my wonderwall", "I said maybe" };
            //File.WriteAllLines(path + "Wonderwall.txt", lines);

            //string[] readlines = File.ReadAllLines(path + "Wonderwall.txt");
            //foreach (string line in readlines)
            //{
            //    Console.WriteLine(line);
            //}
            #endregion

            #region Logging
            //Console.WriteLine($"This is being logged at time {DateTime.Now}");
            //// Listens for debugging or trace output
            //// Writes it to a text file
            //TextWriterTraceListener twtl = new TextWriterTraceListener(File.Create(_path + "TraceOutput.txt"));
            //// Assigns the twtl to a listener
            //Trace.Listeners.Add(twtl);
            //int total = 0;
            //for (int i = 0; i <= 3; i++)
            //{
            //    Console.WriteLine(i);
            //    total += i;
            //    // Useful to find defects
            //    Debug.WriteLine($"Debug - the value of i is {i}");
            //    Trace.WriteLine($"Trace - the value of i is {i}");

            //}
            //Trace.Flush();


            #endregion

            #region Streaming

            //using (StreamWriter sw = File.AppendText(_path + "Mary.txt"))
            //{
            //    sw.WriteLine("Mary had a little lamb");
            //}

            //using (StreamReader sr = File.OpenText(_path + "Mary.txt"))
            //{
            //    string s = "";
            //    while ((s = sr.ReadLine()) != null)
            //    {
            //        Console.WriteLine(s);
            //    }
            //}

            //using (Dan dan = new Dan())
            //{

            //}

            #endregion

            int[] array = new int[] { 1, 2, 3, 4, 5 };
            List<string> names = new List<string>();
            names.Add("Anna");
            names.Add("Emma");
            names.Add("Maks");

            foreach (string name in names)
            {
                Console.WriteLine(name);
            }

            Dictionary<int, string> bestMovies = new Dictionary<int, string>();
            bestMovies.Add(1, "Lord of the Rings");
            bestMovies.Add(2, "Bohemian Rhapsody");
            bestMovies.Add(3, "Fast and Furious");

            foreach (var movie in bestMovies)
            {
                Console.WriteLine(movie.Value);
            }

        }
    }
}