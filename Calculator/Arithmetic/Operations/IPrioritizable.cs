namespace Calculator.Arithmetic.Operations
{
    public interface IPrioritizable
    {
        PrioritizedPart Prioritize(string input, int operationIndex);
    }
}
