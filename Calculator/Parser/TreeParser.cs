﻿using System;
using System.Collections.Generic;
using Calculator.Arithmetic.Operations;
using Calculator.Exceptions;

namespace Calculator.Parser
{
    public class TreeParser : IParser
    {
        public Expression Parse(string input, List<IOperation> operations)
        {
            foreach (IOperation operation in operations)
            {
                int operationIndex = input.LastIndexOf(operation.Sign);
                if (operationIndex != -1 && IsOperation(input, operationIndex))
                {
                    Expression right = Parse(input.Substring(operationIndex + operation.Sign.Length), operations);
                    Expression left = Parse(input.Substring(0, operationIndex), operations);
                    return new Expression(operation.Sign, right, left);
                }
            }

            input = input.Replace(" ", string.Empty);
            CheckIfNumber(input);
            return new Expression(input);
        }

        private void CheckIfNumber(string input)
        {
            try
            {
                double.Parse(input);
            }
            catch (FormatException)
            {
                throw new ParsingException("Cannot parse the expression");
            }
        }

        private bool IsOperation(string input, int operationIndex)
        {
            input = input.Replace(" ", string.Empty);
            if (input[operationIndex] == '-')
            {
                if (operationIndex == 0)
                {
                    return false;
                }

                return char.IsDigit(input[operationIndex - 1]);
            }

            return true;
        }
    }
}
