using System;
using Calculator.Arithmetic.Notations;

namespace Calculator.Arithmetic.Operations
{
    public class Pow : IOperation
    {
        public INotation Notation { get; }
        public bool IsRTL { get; }

        public Pow()
        {
            Notation = new InfixNotation("**", "Pow");
            IsRTL = true;
        }

        public double Operate(double operand1, double operand2)
        {
            return Math.Pow(operand1, operand2);
        }
    }
}
