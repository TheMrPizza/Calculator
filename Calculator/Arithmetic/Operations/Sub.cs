using Calculator.Arithmetic.Notations;

namespace Calculator.Arithmetic.Operations
{
    public class Sub : IOperation
    {
        public INotation Notation { get; }
        public bool IsRTL { get; }

        public Sub()
        {
            Notation = new InfixNotation("-", "Sub");
            IsRTL = false;
        }

        public double Operate(double operand1, double operand2)
        {
            return operand1 - operand2;
        }
    }
}
