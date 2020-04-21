using Calculator.Arithmetic.Notations;

namespace Calculator.Arithmetic.Operations
{
    public class Negation : IOperation
    {
        public INotation Notation { get; }
        public bool IsRTL { get; }

        public Negation()
        {
            Notation = new PrefixNotation("-", "Negation");
            IsRTL = true;
        }

        public double Operate(double operand1, double operand2)
        {
            return -operand1;
        }
    }
}
