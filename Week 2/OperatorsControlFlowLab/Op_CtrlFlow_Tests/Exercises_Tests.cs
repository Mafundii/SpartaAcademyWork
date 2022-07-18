using NUnit.Framework;
using Op_CtrlFlow;
using System;
using System.Collections.Generic;

namespace Op_CtrlFlow_Tests
{
    public class Exercises_Tests
    {
        // write unit test(s) for MyMethod here
        [TestCase(5, 5)]
        public void GivenNum1EqualsNum2_MyMethod_ReturnsFalse(int num1, int num2)
        {
            Assert.That(Exercises.MyMethod(num1, num2), Is.EqualTo(false));
        }

        [TestCase(7, 4)]
        public void GivenNum1IsDIvisibleByNum2_MyMethod_ReturnsFalse(int num1, int num2)
        {
            Assert.That(Exercises.MyMethod(num1, num2), Is.EqualTo(false));
        }

        [TestCase(6, 3)]
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

        [TestCase(-1)]
        [TestCase(-101)]
        public void GivenMarkBelow0_Grade_ReturnsArgumentOutOfRangeEception(int mark)
        {
            Assert.That(() => Exercises.Grade(mark), Throws.TypeOf<ArgumentOutOfRangeException>());
        }

        [TestCase(101)]
        [TestCase(Int32.MaxValue)]
        public void GivenMarkAbove100_Grade_ReturnsArgumentOutOfRangeException(int mark)
        {
            Assert.That(() => Exercises.Grade(mark), Throws.TypeOf<ArgumentOutOfRangeException>());
        }

    }
}
