namespace CalculatorLib
{
    public class Calculator
    {
        public int Num1 { get; set; }
        public int Num2 { get; set; }

        public int Add()
        {
            return Num1 + Num2;
        }

        public int Subtract()
        {
            return Num1 - Num2;
        }
    }
}