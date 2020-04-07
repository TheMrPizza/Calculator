using System.Collections.Generic;
using Calculator.Exceptions;

namespace Calculator.Arithmetic.Operations
{
    public abstract class UnaryOperationBase : IOperation
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
            int endIndex = input.Substring(startIndex).IndexOf(ClosingSign);
            if (endIndex == -1)
            {
                throw new ParsingException("Closing operation not found");
            }
            string content = input.Substring(startIndex, endIndex - startIndex + 1);
            return new Expression(Sign, null, new Expression(content));
        }

        public List<int> GetOperandsIndexes(int operationIndex)
        {
            return new List<int> { operationIndex + Sign.Length };
        }
    }
}
