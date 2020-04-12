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

        public bool Block(IParser parser, Input input, int operationIndex)
        {
            int startIndex = operationIndex;
            int endIndex = FindEndIndex(parser, input, operationIndex);
            if (startIndex == 0 && endIndex == input.Value.Length - 1)
            {
                return false;
            }

            input.Block(operationIndex, endIndex);
            return true;
        }

        public bool IsCorrect(Input input, int operationIndex)
        {
            return input.IsNextOperandCorrect(operationIndex);
        }

        private int FindEndIndex(IParser parser, Input input, int operationIndex)
        {
            int startIndex = operationIndex + Sign.Length;
            for (int i = startIndex; i < input.Value.Length; i++)
            {
                if (input.Value.Substring(i).StartsWith(ClosingSign))
                {
                    try
                    {
                        string content = input.Value.Substring(startIndex, i - startIndex);
                        parser.Parse(content);
                        return i + ClosingSign.Length - 1;
                    }
                    catch (ParsingException)
                    {
                        continue;
                    }
                }
            }

            throw new ParsingException("Closing operation not found");
        }
    }
}
