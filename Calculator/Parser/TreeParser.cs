using Calculator.Arithmetic;
using Calculator.Arithmetic.Operations;

namespace Calculator.Parser
{
    public class TreeParser : IParser
    {
        public Input Input { get; set; }
        public ArithmeticUnit ArithmeticUnit { get; set; }

        public TreeParser(ArithmeticUnit arithmeticUnit)
        {
            Input = null;
            ArithmeticUnit = arithmeticUnit;
        }

        public Expression Parse(string input)
        {
            Input = new Input(input);
            return HandleInput();
        }

        public Expression HandleInput()
        {
            foreach (IOperation operation in ArithmeticUnit.Operations)
            {
                int operationIndex = Input.FindOperationIndex(operation, ArithmeticUnit.Operations);
                if (operationIndex != -1)
                {
                    if (TryBlock(operation, operationIndex))
                    {
                        return HandleInput();
                    }

                    return ParseOperation(operation, operationIndex);
                }
            }

            Input.CheckIfNumber();
            return new Expression(Input.FullValue);
        }

        public Expression ParseOperation(IOperation operation, int operationIndex)
        {
            Expression exp = operation.Parse(Input.FullValue, operationIndex);
            exp.Right = exp.Right == null ? null : Parse(exp.Right.Value);
            exp.Left = exp.Left == null ? null : Parse(exp.Left.Value);
            return exp;
        }

        public bool TryBlock(IOperation operation, int operationIndex)
        {
            if (operation is IBlockable)
            {
                if ((operation as IBlockable).Block(Input, operationIndex))
                {
                    return true;
                }
            }

            return false;
        }
    }
}
