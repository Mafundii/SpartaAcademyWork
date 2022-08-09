namespace CalculatorKataApp
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(Add("1,2"));
        }

        static int Add(string numbers)
        {
            if (numbers is null || numbers.Length == 0)
            {
                return 0;
            }

            var numsArray = numbers.ToArray();
            int total = 0;

            for (int i = 0; i <= numsArray.Length; i++)
            {
                total += numsArray[i];
                
            }

            return total;
        }

    }

}