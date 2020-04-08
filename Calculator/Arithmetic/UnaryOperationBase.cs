using Calculator.Exceptions;
using Calculator.Parser;

namespace Calculator.Arithmetic.Operations
{
    public abstract class UnaryOperationBase : IOperation, IBlockable
    {
        public string Name { get; }
        public string Sign { get; }
        public bool IsRTL { get; }
        public string ClosingSign { get; }

        public UnaryOperationBase(string name, string sign, string closingSign, bool isRTL=false)
        {
            Name = name;
            Sign = sign;
            IsRTL = isRTL;
            ClosingSign = closingSign;
        }

        public abstract double Operate(double operand1, double operand2);

        public virtual Expression Parse(string input, int operationIndex)
        {
            int startIndex = operationIndex + Sign.Length;
            int endIndex = input.LastIndexOf(ClosingSign);
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
            return input.Utils.IsNextOperandCorrect(operationIndex);
        }
    }
}
