using Calculator.Arithmetic.Notations;
using Calculator.Exceptions;

namespace Calculator.Arithmetic.Operations
{
    public class Div : IOperation
    {
        public INotation Notation { get; }
        public bool IsRTL { get; }

        public Div()
        {
            Notation = new InfixNotation("/", "Div");
            IsRTL = false;
        }

        public double Operate(double operand1, double operand2)
        {
            if (operand2 == 0)
            {
                throw new ArithmeticExcpetion("Cannot divide by zero");
            }

            return operand1 / operand2;
        }
    }
}
