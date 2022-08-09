namespace Practice2App
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(SumLoop(5));
            Console.WriteLine(SumRecursive(5));
        }

        public static int SumRecursive(int n)
        {
            if (n == 0) return 0;
            int prev = SumRecursive(n - 1);
            int sum = n + prev;
            return sum;
        }
        public static int SumLoop(int n)
        {
            int sum = 0;
            for (int i = 0; i <= n; i++)
            {
                sum += i;
            }
            return sum;
        }

    }
}