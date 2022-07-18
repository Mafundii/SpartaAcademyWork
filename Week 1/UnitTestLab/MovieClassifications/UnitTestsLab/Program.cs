namespace UnitTestsLab
{
    public class Program
    {
        static void Main(string[] args)
        {            
        }

        public static string AvailableClassifications(int ageOfViewer)
        {
            if (ageOfViewer < 0)
            {
                throw new ArgumentOutOfRangeException();
            }


            string result;
            if (ageOfViewer < 12)
            {
                result = "U and PG films are available.";
            }
            else if (ageOfViewer >= 12 && ageOfViewer < 15)
            {
                result = "U, PG and 12 films are available.";
            }
            else if (ageOfViewer >= 15 && ageOfViewer < 18)
            {
                result = "U, PG, 12 and 15 films are available.";
            }
            else
            {
                result = "All films are available";
            }
            return result;
        }




    }
}