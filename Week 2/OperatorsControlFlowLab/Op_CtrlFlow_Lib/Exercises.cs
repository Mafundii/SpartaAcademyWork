using System.Collections.Generic;
using System;


namespace Op_CtrlFlow
{
    public class Exercises
    {
        public static bool MyMethod(int num1, int num2)
        {
            return num1 == num2 ? false : (num1 % num2) == 0;
        }

        // returns the average of the array nums
        public static double Average(List<int> nums)
        {
            double average;
            double total = 0;
            double count = nums.Count;

            if (count == 0)
            {
                return 0;
            }

            foreach (int i in nums)
            {
                total += i;
            }
            average = total / count;
            return average;
        }

        // returns the type of ticket a customer is eligible for based on their age
        // "Standard" if they are between 18 and 59 inclusive
        // "OAP" if they are 60 or over
        // "Student" if they are 13-17 inclusive
        // "Child" if they are 5-12
        // "Free" if they are under 5
        public static string TicketType(int age)
        {
            string ticketType;
            ticketType = age < 5 ? "Free"
                : age <= 12 ? "Child"
                : age <= 17 ? "Student"
                : age <= 59 ? "Standard"
                : "OAP";
            return ticketType;
        }

        public static string Grade(int mark)
        {
            if (mark < 0 || mark >100)
            {
                throw new ArgumentOutOfRangeException(nameof(mark), "Invalid number");
            }

            string grade;
            grade = mark >= 75 ? "Pass with Distinction"
                : mark >= 60 ? "Pass with Merit"
                : mark >= 40 ? "Pass"
                : "Fail";
            return grade;
        }

        public static int GetScottishMaxWeddingNumbers(int covidLevel)
        {
            return 0;
        }
    }
}
