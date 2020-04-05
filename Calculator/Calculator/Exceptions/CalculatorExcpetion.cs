using System;

namespace Calculator.Exceptions
{
    public class CalculatorExcpetion : Exception
    {
        public CalculatorExcpetion() : base()
        {

        }

        public CalculatorExcpetion(string msg) : base(msg)
        {

        }
    }
}
