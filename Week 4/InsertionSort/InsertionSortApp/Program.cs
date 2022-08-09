namespace InsertionSortApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int min = -100;
            int max = 100;
            int[] randomArray = new int[10];
            Random randomNum = new Random();

            for (int i = 0; i < randomArray.Length; i++)
            {
                randomArray[i] = randomNum.Next(min, max);
            }

            foreach (int i in randomArray)
            {
                Console.WriteLine(i);
            }

            Console.WriteLine();

            InsertionSort(randomArray);

            foreach (int i in randomArray)
            {
                Console.WriteLine(i);
            }

        }

        public static void InsertionSort(int[] array)
        {
            int i = 1;
            int x = 1;
            int temp = 0;

            while (i < array.Length)
            {
                x = i;
                while (x > 0 && array[x - 1] > array[x])
                {
                    temp = array[x];
                    array[x] = array[x - 1];
                    array[x - 1] = temp;
                    x--;
                }
                i++;
            }
        }

    }
}