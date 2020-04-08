using Calculator.Exceptions;

namespace Calculator.Arithmetic.Operations
{
    public class Div : BinaryOperationBase
    {
        public Div() : base("Div", "/")
        {

        }

        public override double Operate(double operand1, double operand2)
        {
            if (operand2 == 0)
            {
                throw new ArithmeticExcpetion("Cannot divide by zero");
            }

            return operand1 / operand2;
        }
    }
}
