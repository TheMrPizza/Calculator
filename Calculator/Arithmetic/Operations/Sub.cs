namespace Calculator.Arithmetic.Operations
{
    public class Sub : BinaryOperationBase
    {
        public Sub() : base("Sub", "-")
        {

        }

        public override double Operate(double operand1, double operand2)
        {
            return operand1 - operand2;
        }
    }
}
