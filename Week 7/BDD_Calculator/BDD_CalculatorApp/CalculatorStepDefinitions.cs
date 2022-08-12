using CalculatorLib;
using System;
using TechTalk.SpecFlow;

namespace BDD_CalculatorApp
{
    [Binding]
    public class CalculatorStepDefinitions
    {
        private Calculator _calculator;
        private int _result;
        private DivideByZeroException _DBZexception;

        [Given(@"I have a calculator")]
        public void GivenIHaveACalculator()
        {
            _calculator = new Calculator();
        }

        [Given(@"I enter (.*) and (.*) in the calculator")]
        public void GivenIEnterAndInTheCalculator(int a, int b)
        {
            _calculator.Num1 = a;
            _calculator.Num2 = b;
        }

        [When(@"I press Add")]
        public void WhenIPressAdd()
        {
            _result = _calculator.Add();
        }

        [When(@"I press Subtract")]
        public void WhenIPressSubtract()
        {
            _result = _calculator.Subtract();
        }

        [When(@"I press Multiply")]
        public void WhenIPressMultiply()
        {
            _result = _calculator.Multiply();
        }

        [When(@"I press Divide")]
        public void WhenIPressDivide()
        {
            try
            {
                _result = _calculator.Divide();
            }
            catch (DivideByZeroException ex)
            {
                _DBZexception = ex;
            }
        }

        [Then(@"An exception shopuld be thrown")]
        public void ThenAnExceptionShopuldBeThrown()
        {
            Assert.That(_calculator.DBZexception, Is.Not.Null);
        }

        [Then(@"The exception should have message ""([^""]*)""")]
        public void ThenTheExceptionShouldHaveMessage(string exceptionMessage)
        {
            Assert.That(_calculator.DBZexception.Message, Is.EqualTo("Cannot divide by zero"));
        }



    }
}
