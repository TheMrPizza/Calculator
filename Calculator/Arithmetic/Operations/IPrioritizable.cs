using Calculator.Parser;

namespace Calculator.Arithmetic.Operations
{
    public interface IPrioritizable
    {
        void Prioritize(Input input, int operationIndex);
    }
}
