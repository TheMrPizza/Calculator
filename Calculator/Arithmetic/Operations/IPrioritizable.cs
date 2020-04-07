using Calculator.Parser;

namespace Calculator.Arithmetic.Operations
{
    public interface IPrioritizable
    {
        SubInput Prioritize(Input input, int operationIndex);
    }
}
