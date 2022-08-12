using System;
using TechTalk.SpecFlow;
using NUnit.Framework;
using CalculatorLib;

namespace BDD_Calculator
{
    [Binding]
    public class CalculatorStepDefinitions
    {
        private Calculator _calulator;
        private int _result;

        [Given(@"I have a calculator")]
        public void GivenIHaveACalculator()
        {
            _calulator = new Calculator();
        }

        [Given(@"I enter (.*) and (.*) in the calculator")]
        public void GivenIEnterAndInTheCalculator(int a, int b)
        {
            _calulator.Num1 = a;
            _calulator.Num2 = b;
        }

        [When(@"I press add")]
        public void WhenIPressAdd()
        {
            _result = _calulator.Add();
        }
        [When(@"I press subtract")]
        public void WhenIPressSubtract()
        {
            _result = _calulator.Subtract();
        }

        [Then(@"the result should be (.*)")]
        public void ThenTheResultShouldBe(int expected)
        {
            Assert.That(_result, Is.EqualTo(expected));
        }
    }
}
