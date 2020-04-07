using Calculator.Parser;

namespace Calculator.Arithmetic.Operations
{
    public interface IBlockable
    {
        bool Block(Input input, int operationIndex);
    }
}
