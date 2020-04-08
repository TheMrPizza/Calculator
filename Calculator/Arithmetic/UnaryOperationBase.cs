using System.Collections.Generic;
using Calculator.Exceptions;
using Calculator.Parser;

namespace Calculator.Arithmetic.Operations
{
    public abstract class UnaryOperationBase : IOperation, IBlockable
    {
        public string Name { get; }
        public string Sign { get; }
        public string ClosingSign { get; }

        public UnaryOperationBase(string name, string sign, string closingSign)
        {
            Name = name;
            Sign = sign;
            ClosingSign = closingSign;
        }

        public abstract double Operate(double operand1, double operand2);

        public virtual Expression Parse(string input, int operationIndex)
        {
            int startIndex = operationIndex + Sign.Length;
            int endIndex = input.LastIndexOf(ClosingSign);
            if (endIndex == -1)
            {
                throw new ParsingException("Closing operation not found");
            }

            string content = input.Substring(startIndex, endIndex - startIndex);
            return new Expression(Name, null, new Expression(content));
        }

        public bool Block(Input input, int operationIndex)
        {
            int startIndex = operationIndex;
            int endIndex = input.Value.Substring(startIndex + Sign.Length).LastIndexOf(ClosingSign);
            if (endIndex == -1)
            {
                throw new ParsingException("Closing operation not found");
            }

            endIndex += startIndex + Sign.Length;
            if (startIndex == 0 && endIndex == input.Value.Length - 1)
            {
                return false;
            }

            input.Block(startIndex, endIndex);
            return true;
        }

        public bool IsOperationCorrect(Input input, int operationIndex)
        {
            return input.IsNextOperandCorrect(operationIndex);
        }
    }
}
