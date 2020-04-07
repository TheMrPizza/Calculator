namespace Calculator.Arithmetic.Operations
{
    public interface IOperation
    {
        string Sign { get; }

        double Operate(double operand1, double operand2);

        Expression Parse(string input, int operationIndex);
    }
}
