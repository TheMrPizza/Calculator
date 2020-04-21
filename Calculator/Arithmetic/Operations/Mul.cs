using Calculator.Arithmetic.Notations;

namespace Calculator.Arithmetic.Operations
{
    public class Mul : IOperation
    {
        public INotation Notation { get; }
        public bool IsRTL { get; }

        public Mul()
        {
            Notation = new InfixNotation("*", "Mul");
            IsRTL = false;
        }

        public double Operate(double operand1, double operand2)
        {
            return operand1 * operand2;
        }
    }
}
