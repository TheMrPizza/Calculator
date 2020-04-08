using System;

namespace Calculator.Arithmetic.Operations
{
    public class Pow : BinaryOperationBase
    {
        public Pow() : base("Pow", "**")
        {

        }

        public override double Operate(double operand1, double operand2)
        {
            return Math.Pow(operand1, operand2);
        }
    }
}
