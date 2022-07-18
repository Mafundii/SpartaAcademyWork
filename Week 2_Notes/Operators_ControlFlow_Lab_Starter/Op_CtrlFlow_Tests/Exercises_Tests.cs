using NUnit.Framework;
using Op_CtrlFlow;
using System.Collections.Generic;
using System;

namespace Op_CtrlFlow_Tests
{
    public class Exercises_Tests
    {
        // Unit test(s) for MyMethod here
        // MyMethod returns false if num1 and num2 are equal
        [TestCase(6, 6)]
        public void GivenNum1IsEqualToNum2_MyMethod_ReturnsFalse(int num1, int num2)
        {
            Assert.That(Exercises.MyMethod(num1, num2), Is.EqualTo(false));
        }
        // MyMethod returns false is num1 is not divisible by num2
        [TestCase(3, 9)]
        public void GivenNum1IsNotDivisibleByNum2_MyMethod_ReturnsFalse(int num1, int num2)
        {
            Assert.That(Exercises.MyMethod(num1, num2), Is.EqualTo(false));
        }
        // MyMethod returns true if num1 is divisible by num2
        [TestCase(8, 4)]
        public void GivenNum1IsDivisibleByNum2_MyMethod_ReturnsTrue(int num1, int num2)
        {
            Assert.That(Exercises.MyMethod(num1, num2), Is.EqualTo(true));
        }
       


        [Test]
        public void Average_ReturnsCorrectAverage()
        {
            var myList = new List<int>() { 3, 8, 1, 7, 3 };
            Assert.That(Exercises.Average(myList), Is.EqualTo(4.4));
        }

        [Test]
        public void WhenListIsEmpty_Average_ReturnsZero()
        {
            var myList = new List<int>() {};
            Assert.That(Exercises.Average(myList), Is.EqualTo(0));
        }

        [TestCase(100, "OAP")]
        [TestCase(60, "OAP")]
        [TestCase(59, "Standard")]
        [TestCase(18, "Standard")]
        [TestCase(17, "Student")]
        [TestCase(13, "Student")]
        [TestCase(12, "Child")]
        [TestCase(5, "Child")]
        [TestCase(4, "Free")]
        [TestCase(0, "Free")]
        public void TicketTypeTest(int age, string expected)
        {
            var result = Exercises.TicketType(age);
            Assert.That(result, Is.EqualTo(expected));
        }

        // Boundary Cases for Grade Tests
        [TestCase(0, "Fail")]
        [TestCase(39, "Fail")]
        [TestCase(40, "Pass")]
        [TestCase(50, "Pass")]
        [TestCase(60, "Pass with Merit")]
        [TestCase(74, "Pass with Merit")]
        [TestCase(75, "Pass with Distinction")]
        [TestCase(100, "Pass with Distinction")]
        public void GivenBoundaryMarks_Grade_ReturnsExpectedResult(int mark, string expectedResult)
        {
            Assert.That(Exercises.Grade(mark), Is.EqualTo(expectedResult));
        }

        //Tests for out of range marks
        [TestCase(101)]
        [TestCase(int.MaxValue)]    
        public void GivenOutOfRangeMarks_Grade_ReturnsArgumentOutOfBoundsException(int mark)
        {
            Assert.That(() => Exercises.Grade(mark), Throws.TypeOf<ArgumentOutOfRangeException>());
              
        }

        //Test Cases for negative numbers
        [TestCase(-1)]
        [TestCase(int.MinValue)]
        public void GivenNegativeMarks_Grade_ReturnsArgumentOutOfBoundsException(int mark)
        {
            Assert.That(() => Exercises.Grade(mark), Throws.TypeOf<ArgumentOutOfRangeException>());
        }



    }
}
