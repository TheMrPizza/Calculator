using Calculator.Parser;

namespace Calculator.Arithmetic.Operations
{
    public interface IBlockable
    {
        void Block(Input input, int operationIndex);
    }
}
