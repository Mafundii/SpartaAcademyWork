namespace ExceptionsApp
{
    public class Program
    {
        static void Main(string[] args)
        {
            ////var theBeatles = new String[] { "John", "Paul", "Ringo", "George" };
            ////theBeatles[4] = "Yoko";

            //string Text;
            //string fileName = "Wonderwall.txt";

            //try
            //{
            //    Text = File.ReadAllText(fileName);
            //    Console.WriteLine(Text);
            //}
            //catch(FileNotFoundException ex)
            //{
            //    Console.WriteLine("Sorry can't find " + fileName);
            //}
            //try
            //{
            //    Console.WriteLine("Maks recieved 88: " + Grade(88));
            //    Console.WriteLine("John recieved -100: " + Grade(-100));
            //}
            //catch (ArgumentOutOfRangeException ex)
            //{                                      
            //    Console.WriteLine(ex.ToString());

            //    Console.WriteLine(ex.Message);
            //}
            //finally
            //{
            //    Console.WriteLine("I will always execute");
            //}

            #region Data Types
            //decimal sum = 0;           
            //for (int i = 0; i < 100_000; i++) 
            //{
            //    sum += 2 / 5.0m;
            //}
            //Console.WriteLine("2/5 added 100,000 times: " + sum);
            //Console.WriteLine("2/5 multiplied 100,000: " + 2/5.0f * 100_000);


            //var result = 5.50 / 5;

            //int a = 3;
            //double b = a;

            //double c = 3.1;
            //int d = (int)c;

            //int max = int.MaxValue;
            //max++;

            //Console.WriteLine(max);

            // Overflow
            //sbyte sNum = SByte.MaxValue;
            //Console.WriteLine("Sbyte max: " + sNum);
            //sNum += 1;
            //Console.WriteLine(sNum);

            //int bankBalance = -2;
            //uint posBalance = (uint)bankBalance;

            //Console.WriteLine(Convert.ToString(bankBalance, 2));
            //Console.WriteLine(Convert.ToString(posBalance, 2));

            //char n = 'N';
            //Console.WriteLine((int)n);

            //var theInt = 78;
            //var anotherInt = Convert.ToChar(theInt);

            //Console.WriteLine(anotherInt);  

            //double myDouble = 3.4;
            //int myInt2 = Convert.ToInt32(myDouble);

            //Console.WriteLine(myInt2);  

            #endregion

           






        }

        //public static string Grade(int mark)
        //{
        //    if (mark < 0 || mark > 100)
        //    {
        //        throw new ArgumentOutOfRangeException("Mark: " + mark + " Allowed range 0-100");
        //    }                      
        //        return mark >= 65 ? (mark >= 85 ? "Distinction" : "Pass") : "Fail";                        
        //}

    }
}