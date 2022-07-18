using System;
using System.Collections.Generic;

namespace MoreTypes_Lib
{
    public class ArraysExercises
    {
        // returns a 1D array containing the contents of a given List
        public static string[] Make1DArray(List<string> contents)
        {
            string[] array1D = contents.ToArray();
            return array1D;
        }

        // returns a 3D array containing the contents of a given List
        public static string[,,] Make3DArray(int length1, int length2, int length3, List<string> contents)
        {
            if ((length1 * length2 * length3) != contents.Count)
                throw new ArgumentException("Number of elements in list must match array size");
            
            string[,,] array3D = new string[length1, length2, length3];
            int index = 0;
            for (int i = 0; i < length1; i++)
            {
                for (int j = 0; j < length2; j++)
                {
                    for (int k = 0; k < length3; k++)
                    {
                        array3D[i, j, k] = contents[index++];                        
                    }
                }
            }
            return array3D;
        }

        // returns a jagged array containing the contents of a given List
        public static string[][] MakeJagged2DArray(int countRow1, int countRow2, List<string> contents)
        {
            if ((countRow1 + countRow2) != contents.Count)
                throw new ArgumentException("Number of elements in list must match array size");

            string[][] jaggedArray = new string[2][];
            int index = 0;

            jaggedArray[0] = new string[countRow1];
            for (int i = 0; i < countRow1; i++)
            {
                jaggedArray[0][i] = contents[index++];               
            }

            jaggedArray[1] = new string[countRow2];
            for (int j = 0; j < countRow2; j++)
            {
                jaggedArray[1][j] = contents[index++];
            }

            return jaggedArray;
            
        }
    }
}
