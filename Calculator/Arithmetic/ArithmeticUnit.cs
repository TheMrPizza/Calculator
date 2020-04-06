using Calculator.Exceptions;

namespace Calculator.Arithmetic
{
    public class ArithmeticUnit
    {
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
