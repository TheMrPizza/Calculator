using Calculator.Arithmetic.Notations;

namespace Calculator.Arithmetic.Operations
{
    public interface IOperation
    {
        INotation Notation { get; }
        bool IsRTL { get; }

        double Operate(double operand1, double operand2);
    }
}
