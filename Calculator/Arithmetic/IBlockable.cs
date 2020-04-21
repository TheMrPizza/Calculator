using Calculator.Parser;

namespace Calculator.Arithmetic.Operations
{
    public interface IBlockable
    {
        bool Block(IParser parser, Input input, int operationIndex);
    }
}
