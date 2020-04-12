using Calculator.Parser;

namespace Calculator.Arithmetic.Operations
{
    public abstract class BinaryOperationBase
    {
        public string Name { get; }
        public string Sign { get; }
        public bool IsRTL { get; }

        public BinaryOperationBase(string name, string sign, bool isRTL=false)
        {
            Name = name;
            Sign = sign;
            IsRTL = isRTL;
        }

        public abstract double Operate(double operand1, double operand2);

        public virtual Expression Parse(string input, int operationIndex)
        {
            Expression right = new Expression(input.Substring(operationIndex + Sign.Length));
            Expression left = new Expression(input.Substring(0, operationIndex));
            return new Expression(Name, right, left);
        }

        public bool IsOperationCorrect(Input input, int operationIndex)
        {
            return input.Utils.IsPrevOperandCorrect(operationIndex) &&
                input.Utils.IsNextOperandCorrect(operationIndex + Sign.Length - 1);
        }
    }
}
