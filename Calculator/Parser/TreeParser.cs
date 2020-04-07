using System;
using System.Collections.Generic;
using Calculator.Arithmetic.Operations;
using Calculator.Exceptions;

namespace Calculator.Parser
{
    public class TreeParser : IParser
    {
        public Expression Parse(string input, List<IOperation> operations)
        {
            int start = 0;
            int end = input.Length;
            foreach (IOperation operation in operations)
            {
                int operationIndex = input.LastIndexOf(operation.Sign);
                if (operationIndex != -1 && IsOperation(input, operationIndex))
                {
                    Expression exp = operation.Parse(input, operationIndex);
                    exp.Right = Parse(exp.Right.Value, operations);
                    exp.Left = Parse(exp.Left.Value, operations);
                    return exp;
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
