namespace PallindromeApp
{
    public class Program
    {
        static void Main(string[] args)
        {
            // A Pallindrome is a word that reads the same forwards as it does backwards, 
            // for example: racecar or kayak.

            

        }
        public static bool IsPallindrome(string original)
        {
            if (original is null)
            {
                throw new ArgumentException();
            }

            if (original.Length == 1) { return true; }

            string reversed = "";
            for (int i = original.Length - 1; i >= 0; i--)
            {
                reversed += original[i].ToString();
            }

            if (reversed == original)
            {
                return true;
            }
            else
            {
                return false;
            }

        }
    }
}