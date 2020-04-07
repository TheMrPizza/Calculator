﻿using System.Collections.Generic;

namespace Calculator.Arithmetic.Operations
{
    public abstract class BinaryOperationBase : IOperation
    {
        public string Sign { get; }

        public BinaryOperationBase(string sign)
        {
            Sign = sign;
        }

        public abstract double Operate(double operand1, double operand2);

        public Expression Parse(string input, int operationIndex)
        {
            Expression right = new Expression(input.Substring(operationIndex + Sign.Length));
            Expression left = new Expression(input.Substring(0, operationIndex));
            return new Expression(Sign, right, left);
        }

        public List<int> GetOperandsIndexes(int operationIndex)
        {
            return new List<int> { operationIndex - 1, operationIndex + Sign.Length };
        }
    }
}
