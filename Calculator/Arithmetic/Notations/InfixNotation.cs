using Calculator.Parser;

namespace Calculator.Arithmetic.Notations
{
    public class InfixNotation : INotation
    {
        public string Sign { get; }
        public string Name { get; }

        public InfixNotation(string sign, string name)
        {
            Sign = sign;
            Name = name;
        }

        public Expression Parse(string input, int operationIndex)
        {
            Expression right = new Expression(input.Substring(operationIndex + Sign.Length));
            Expression left = new Expression(input.Substring(0, operationIndex));
            return new Expression(Name, right, left);
        }

        public bool IsCorrect(Input input, int operationIndex)
        {
            return input.IsPrevOperandCorrect(operationIndex) &&
                input.IsNextOperandCorrect(operationIndex + Sign.Length - 1);
        }
    }
}
