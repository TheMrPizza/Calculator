using Calculator.Parser;

namespace Calculator.Arithmetic.Operations
{
    public interface IOperation
    {
        string Name { get; }
        string Sign { get; }
        bool IsRTL { get; }

        double Operate(double operand1, double operand2);

        Expression Parse(string input, int operationIndex);

        bool IsOperationCorrect(Input input, int operationIndex);
    }
}
