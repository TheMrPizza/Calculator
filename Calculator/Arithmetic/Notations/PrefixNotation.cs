using Calculator.Parser;

namespace Calculator.Arithmetic.Notations
{
    public class PrefixNotation : INotation
    {
        public string Sign { get; }
        public string Name { get; }

        public PrefixNotation(string sign, string name)
        {
            Sign = sign;
            Name = name;
        }

        public Expression Parse(string input, int operationIndex)
        {
            Expression left = new Expression(input.Substring(operationIndex + Sign.Length));
            return new Expression(Name, null, left);
        }

        public bool IsCorrect(Input input, int operationIndex)
        {
            return input.Utils.IsNextOperandCorrect(operationIndex);
        }
    }
}
