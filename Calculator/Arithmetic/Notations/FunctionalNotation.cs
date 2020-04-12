using Calculator.Arithmetic.Operations;
using Calculator.Parser;
using Calculator.Exceptions;

namespace Calculator.Arithmetic.Notations
{
    public class FunctionalNotation : INotation, IBlockable
    {
        public string Sign { get; }
        public string ClosingSign { get; }
        public string Name { get; }

        public FunctionalNotation(string sign, string closingSign, string name)
        {
            Sign = sign;
            ClosingSign = closingSign;
            Name = name;
        }

        public Expression Parse(string input, int operationIndex)
        {
            int startIndex = operationIndex + Sign.Length;
            int endIndex = input.LastIndexOf(ClosingSign);
            string content = input.Substring(startIndex, endIndex - startIndex);
            return new Expression(Name, null, new Expression(content));
        }

        public bool Block(Input input, int operationIndex)
        {
            if (operationIndex == 0 && input.Value.LastIndexOf(ClosingSign) == input.Value.Length - 1)
            {
                return false;
            }

            int startIndex = operationIndex;
            int endIndex = input.Value.Substring(startIndex + Sign.Length).IndexOf(ClosingSign);
            if (endIndex == -1)
            {
                throw new ParsingException("Closing operation not found");
            }

            endIndex += startIndex + Sign.Length;
            input.Block(startIndex, endIndex);
            return true;
        }

        public bool IsCorrect(Input input, int operationIndex)
        {
            return input.IsNextOperandCorrect(operationIndex);
        }
    }
}
