using System.Collections.Generic;
using System;

namespace Op_CtrlFlow
{
    public class Exercises
    {
        // 
        public static bool MyMethod(int num1, int num2)
        {          
            return num1 == num2 ? false : (num1 % num2) == 0;
        }

        // returns the average of the array nums
        public static double Average(List<int> nums)
        {
            if (nums.Count < 1)
            {
                return 0.0;                
            }    
            else
            {
                double sum = 0.0;
                {
                    foreach (int num in nums)
                        sum += num;                   
                }
                return sum / nums.Count;
            }
        }

        // returns the type of ticket a customer is eligible for based on their age
        // "Standard" if they are between 18 and 59 inclusive
        // "OAP" if they are 60 or over
        // "Student" if they are 13-17 inclusive
        // "Child" if they are 5-12
        // "Free" if they are under 5
        public static string TicketType(int age)
        {
            if (age < 0)
            {
                throw new ArgumentOutOfRangeException();
            }
            else
            {
                string ticketType = string.Empty;
                ticketType = age < 5 ? "Free"
                    : age <= 12 ? "Child"
                    : age <= 17 ? "Student"
                    : age <= 59 ? "Standard"
                    : "OAP";

                return ticketType;
            }  
        }

        public static string Grade(int mark)
        {
            if (mark < 0 || mark > 100)
            {
                throw new ArgumentOutOfRangeException();
            }
            else
            {
            
                var grade = "";

                if (mark >= 0 && mark <= 39)
                {
                    grade += "Fail";
                }
                else if (mark >= 40 && mark <= 59)
                {
                    grade += "Pass";
                }
                else if (mark >= 60 && mark <= 74)
                {
                    grade += "Pass with Merit";
                }
                else if (mark >= 75 && mark <= 100)
                {
                    grade += "Pass with Distinction";
                }
                        
                return grade;                
            }
        }

        

        public static int GetScottishMaxWeddingNumbers(int covidLevel)
        {
            return 0;
        }
    }
}
