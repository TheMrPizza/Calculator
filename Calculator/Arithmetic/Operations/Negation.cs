namespace Calculator.Arithmetic.Operations
{
    public class Negation : UnaryOperationBase
    {
        public Negation() : base("Negation", "-", string.Empty)
        {

        }

        public override double Operate(double operand1, double operand2)
        {
            return -operand1;
        }

        public override Expression Parse(string input, int operationIndex)
        {
            string content = input.Substring(operationIndex + 1);
            return new Expression(Name, null, new Expression(content));
        }
    }
}
