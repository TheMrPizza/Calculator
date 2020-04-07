﻿namespace Calculator.Arithmetic.Operations
{
    public class Mul : BinaryOperationBase
    {
        public Mul() : base("*")
        {

        }

        public override double Operate(double operand1, double operand2)
        {
            return operand1 * operand2;
        }
    }
}