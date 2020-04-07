using Calculator.Parser;

namespace Calculator.Arithmetic.Operations
{
    public class Sub : BinaryOperationBase, IBlockable
    {
        public Sub() : base("-")
        {

        }

        public override double Operate(double operand1, double operand2)
        {
            return operand1 - operand2;
        }

        public void Block(Input input, int operationIndex)
        {
            if (operationIndex != 0 && !char.IsDigit(input.Value[operationIndex - 1]))
            {
                input.Block(operationIndex, operationIndex);
            }
        }
    }
}
