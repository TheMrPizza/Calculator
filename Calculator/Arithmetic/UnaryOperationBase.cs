using System.Collections.Generic;
using Calculator.Exceptions;
using Calculator.Parser;

namespace Calculator.Arithmetic.Operations
{
    public abstract class UnaryOperationBase : IOperation, IBlockable
    {
        public string Sign { get; }
        public string ClosingSign { get; }

        public UnaryOperationBase(string sign, string closingSign)
        {
            Sign = sign;
            ClosingSign = closingSign;
        }

        public abstract double Operate(double operand1, double operand2);

        public Expression Parse(string input, int operationIndex)
        {
            int startIndex = operationIndex + Sign.Length;
            int endIndex = input.LastIndexOf(ClosingSign);
            if (endIndex == -1)
            {
                throw new ParsingException("Closing operation not found");
            }

            string content = input.Substring(startIndex, endIndex - startIndex);
            return new Expression(Sign, null, new Expression(content));
        }

        public bool Block(Input input, int operationIndex)
        {
            int startIndex = operationIndex;
            int endIndex = input.Value.LastIndexOf(ClosingSign);
            if (operationIndex == 0 && endIndex == input.Value.Length - 1)
            {
                return false;
            }

            if (endIndex == -1)
            {
                throw new ParsingException("Closing operation not found");
            }

            input.Block(startIndex, endIndex);
            return true;
        }

        public List<int> GetOperandsIndexes(int operationIndex)
        {
            return new List<int> { operationIndex + Sign.Length };
        }
    }
}
