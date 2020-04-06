using System.Collections.Generic;
using Calculator.Exceptions;

namespace Calculator.Arithmetic
{
    public class ArithmeticUnit
    {
        public List<Operation> Operations { get; }

        public ArithmeticUnit()
        {
            // The operations will be solved by their order here
            Operations = new List<Operation>
            {
                new Operation("+", Add, 0),
                new Operation("-", Sub, 0),
                new Operation("*", Mul, 1),
                new Operation("/", Div, 1)
            };
        }

        public double Add(double num1, double num2)
        {
            return num1 + num2;
        }

        public double Sub(double num1, double num2)
        {
            return num1 - num2;
        }

        public double Mul(double num1, double num2)
        {
            return num1 * num2;
        }

        public double Div(double num1, double num2)
        {
            if (num2 == 0)
            {
                throw new ArithmeticExcpetion("Cannot divide by zero");
            }
            
            return num1 / num2;
        }
    }
}
