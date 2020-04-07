using System;

namespace Calculator.Arithmetic.Operations
{
    public class Abs : UnaryOperationBase
    {
        public Abs() : base("|", "|")
        {

        }

        public override double Operate(double operand1, double operand2)
        {
            return Math.Abs(operand1);
        }
    }
}
