using Calculator.Parser;

namespace Calculator.Arithmetic.Notations
{
    public class FunctionalNotation : INotation
    {
        public string Sign { get; }
        public string ClosingSign { get; }
        public string Name { get; }

        public FunctionalNotation(string sign, string name)
        {
            Sign = sign;
            Name = name;
        }

        public Expression Parse(string input, int operationIndex)
        {
            int startIndex = operationIndex + Sign.Length;
            int endIndex = input.LastIndexOf(ClosingSign);
            string content = input.Substring(startIndex, endIndex - startIndex);
            return new Expression(Name, null, new Expression(content));
        }

        public bool IsCorrect(Input input, int operationIndex)
        {
            return input.Utils.IsNextOperandCorrect(operationIndex);
        }
    }
}
