using Calculator.Arithmetic.Notations;
using System;

namespace Calculator.Arithmetic.Operations
{
    public class Abs : IOperation
    {
        public INotation Notation { get; }
        public bool IsRTL { get; }

        public Abs()
        {
            Notation = new FunctionalNotation("|", "|", "Abs");
            IsRTL = true;
        }

        public double Operate(double operand1, double operand2)
        {
            return Math.Abs(operand1);
        }
    }
}
