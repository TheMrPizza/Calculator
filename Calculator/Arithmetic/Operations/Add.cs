namespace Calculator.Arithmetic.Operations
{
    public class Add : BinaryOperationBase
    {
        public Add() : base("Add", "+")
        {

        }

        public override double Operate(double operand1, double operand2)
        {
            return operand1 + operand2;
        }
    }
}
