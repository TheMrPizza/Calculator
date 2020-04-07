namespace Calculator.Arithmetic.Operations
{
    public interface IPrioritizable
    {
        SubInput Prioritize(string input, int operationIndex);
    }
}
