using Calculator.Arithmetic.Notations;

namespace Calculator.Arithmetic.Operations
{
    public class Add : IOperation
    {
        public INotation Notation { get; }
        public bool IsRTL { get; }

        public Add()
        {
            Notation = new InfixNotation("+", "Add");
            IsRTL = false;
        }

        public double Operate(double operand1, double operand2)
        {
            return operand1 + operand2;
        }
    }
}
