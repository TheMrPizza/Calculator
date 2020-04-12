using Calculator.Arithmetic.Operations;
using Calculator.Parser;

namespace Calculator.Arithmetic.Notations
{
    public class PrefixNotation : INotation, IBlockable
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

        public bool Block(Input input, int operationIndex)
        {
            if (operationIndex == 0)
            {
                return false;
            }

            input.Block(operationIndex, operationIndex + Sign.Length);
            return true;
        }

        public bool IsCorrect(Input input, int operationIndex)
        {
            return input.Utils.IsNextOperandCorrect(operationIndex);
        }
    }
}
