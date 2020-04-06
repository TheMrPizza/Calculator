using System;
using System.Collections.Generic;
using Calculator.Arithmetic;
using Calculator.Exceptions;

namespace Calculator.Parser
{
    public class TreeParser : IParser
    {
        public Expression Parse(string input, List<Operation> operations)
        {
            foreach (Operation operation in operations)
            {
                int operationIndex = input.IndexOf(operation.Sign);
                if (operationIndex != -1)
                {
                    Expression right = Parse(input.Substring(0, operationIndex), operations);
                    Expression left = Parse(input.Substring(operationIndex + operation.Sign.Length), operations);
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
    }
}
