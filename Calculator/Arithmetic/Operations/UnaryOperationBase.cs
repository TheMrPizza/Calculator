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
            int endIndex = input.IndexOf(ClosingSign);
            string content = input.Substring(startIndex, endIndex - startIndex);
            return new Expression(Sign, null, new Expression(content));
        }
    }
}
