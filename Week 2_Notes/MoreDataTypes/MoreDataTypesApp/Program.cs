using System;
using System.Text;

namespace MoreDataTypesApp
{
    public enum Pokemon
    {
        GRASS, FIRE, ELEC, WATER
    }
    public class Program
    {
        static void Main(string[] args)
        {
            #region String Data Types
            //Console.WriteLine("Hello World!");

            //String message = "I like donuts. ";

            //message = message.Insert(message.Length - 1, " Actually, I don't like donuts");

            //Console.WriteLine(message);

            //string reminder = "Don't forget to cook it!";

            //string completeMessage = String.Concat(message, reminder);

            //Console.WriteLine(message + reminder);

            //Console.WriteLine(completeMessage);

            #endregion

            //Console.WriteLine(StringExercise("  C# list fundamentals "));

            //Console.WriteLine(StringBuilderExercise("  C# list fundamentals "));

            #region String Interpolation

            //string a = "A";
            //string b = "B";
            //string aAndB = a + b;
            //Console.WriteLine(aAndB);

            //aAndB = string.Concat(a, b);
            //Console.WriteLine(aAndB);




            //// Method Overloading
            //Console.WriteLine(String.Concat(arrayOfStrings));
            //Console.WriteLine(String.Concat(arrayOfChars));

            //string interpolatedString = $"Your blood type is {a} {b.ToLower()}.";
            //Console.WriteLine(interpolatedString);

            //int num1 = 2;
            //int num2 = 7;

            //string logOfNum1Num2 = $"The Log to base {num1} of {num2} is {Math.Log(num1, num2):0.###}";
            //Console.WriteLine(logOfNum1Num2);

            //string money = $"The change is {(num2 - num1):C}";
            //Console.WriteLine(money);



            #endregion

            #region Parsing Strings

            //ParsingStrings();



            #endregion

            #region Arrays

            //string[] arrayOfStrings = { "Hello", " World" };
            //char[] arrayOfChars = { 'a', 'b', 'c' };
            //int[] arrayOfInts = new int[10];

            //arrayOfInts[6] = 7;

            // 1D Arrays
            //int[] arrayOfInts = { 1, 2, 3, 4, 5 };
            //string sparta = "Sparta Global";
            //var spartaArray = sparta.ToCharArray();

            //var anotherSparta = "Hello, Hi, Hola, Hallo, Hej";
            //var anotherArray = anotherSparta.Split(',');

            //// 2D Arrays

            //int[,] grid = new int[2, 4];
            //grid[0, 1] = 6;
            //grid[1, 3] = 8;

            //foreach(var element in grid)
            //{
            //    Console.WriteLine(element);
            //}

            //string[,] chessBoard = { {"pawn", "king" },
            //                         {"blank", "blank"},
            //                         {"enemy king", "enemy pawn" }};

            //int lower1D = chessBoard.GetLowerBound(0);
            //int lower2D = chessBoard.GetLowerBound(1);

            //int upper1D = chessBoard.GetUpperBound(0);
            //int upper2D = chessBoard.GetUpperBound(1);

            //string theBoard = " ";
            //for (int i = lower1D; i <= upper1D; i++)
            //{
            //    for (int j = lower2D; j <= upper2D; j++)
            //    {
            //        theBoard += $"{chessBoard[i, j]} is at {i} and {j}\n";
            //    }
            //}
            //Console.WriteLine(theBoard);

            #endregion

            #region Jagged Arrays

            //int[][] jaggedIntArray = new int[2][];
            //jaggedIntArray[0] = new int[4];
            //jaggedIntArray[1] = new int[2];

            //jaggedIntArray[0][3] = 666;

            //jaggedIntArray[0] = new int[] {1 ,1 ,1 ,1 };





            #endregion

            #region DateTime

            //var whatTimeIsIt = DateTime.Now;

            //Console.WriteLine(whatTimeIsIt);


            #endregion

            #region ENums

            Pokemon type = Pokemon.FIRE;

            if (type == Pokemon.WATER) Console.WriteLine("Water is the type");
            else if (type == Pokemon.FIRE) Console.WriteLine("Fire is the type");

            switch (type)
            {
                case Pokemon.ELEC:
                    Console.WriteLine("Bzz");
                    break;
                case Pokemon.GRASS:
                    Console.WriteLine("The worst type");
                    break;
                case Pokemon.FIRE:
                    Console.WriteLine($"Beats {Pokemon.GRASS}");
                    break;
                default:
                    Console.WriteLine("No type found");
                    break;

            }






            #endregion

        }

        public static void ParsingStrings()
        {
            //Console.WriteLine("How many cars do you own?");
            //string input = Console.ReadLine();
            ////int numCars = Int32.TryParse(input)

            //var success = Int32.TryParse(input, out int NumCars);

            //Console.WriteLine(NumCars);




        }


        #region String Exercise
        //public static string StringExercise(string myString)
        //{


        //    string trimmedString = myString.Trim();
        //    string upperString = trimmedString.ToUpper();
        //    string replacedString = upperString.Replace('L', '*');
        //    string replacedString2 = replacedString.Replace('T', '*');
        //    var nPos = replacedString2.IndexOf('N');
        //    var finalString = replacedString2.Remove(nPos + 1);
        //    return finalString;



        //}
        #endregion

        #region Using String Builder
        //public static string StringBuilderExercise(string myString)
        //{

        //    string ucTrimmedString = myString.Trim().ToUpper();
        //    int nPos = ucTrimmedString.IndexOf('N');

        //    StringBuilder sb = new StringBuilder(ucTrimmedString);
        //    sb.Replace('L', '*').Replace('T', '*');
        //    sb.Remove(nPos + 1, sb.Length - nPos - 1);

        //    return sb.ToString();


        //}
        #endregion
    }
}