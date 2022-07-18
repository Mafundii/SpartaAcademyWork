using System;

namespace DataTypes_Lib
{
    public static class Methods
    {
        // write a method to return the product of all numbers from 1 to n inclusive
        public static long Factorial(int n)
        {
            long total = 1;
            for (int i = 1; i <= n; i++)
            {
                total *= i;
            }
            return total;
        }

        public static float Mult(float num1, float num2)
        {
            return num1 * num2;
        }
    }
}
