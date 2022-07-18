using System;
using System.Collections.Generic;
using System.Linq;

namespace Collections_Lib
{
    public class CollectionsExercises
    {

        /* removes and returns the next num entries in the queue, as a comma separated string */
        public static string NextInQueue(int num, Queue<string> queue)
        {
            throw new NotImplementedException();
        }

        /* uses a Stack to create and return array of ints in reverse order to the one supplied */
        public static int[] Reverse(int[] original)
        {
            throw new NotImplementedException();


        }
        // using a Dictionary, counts and returns (as a string) the occurence of the digits 0-9 in the given string
        public static string CountDigits(string input)
        {
            if (input == "")
            {
                return "";
            }

            var dictCount = new Dictionary<int, int>();

            foreach (char c in input)
            {
                if (Int32.TryParse(c.ToString(), out int result))
                {
                    if (dictCount.ContainsKey(result))
                    {
                        dictCount[result]++;
                    }
                    else
                    {
                        dictCount.Add(result, 1);
                    }

                }
            }
            string output = "";
            foreach (var entry in dictCount)
            {
                output += entry;
            }

            return output;

        }
    }
}
