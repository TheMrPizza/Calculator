using System;
using System.Collections.Generic;
using Calculator.Exceptions;

namespace Calculator.Parser
{
    public class TreeParser : IParser
    {
        public Expression Parse(string input, List<string> operations)
        {
            foreach (string operation in operations)
            {
                int operationIndex = input.IndexOf(operation);
                if (operationIndex != -1)
                {
                    Expression right = Parse(input.Substring(0, operationIndex), operations);
                    Expression left = Parse(input.Substring(operationIndex + operation.Length), operations);
                    return new Expression(operation, right, left);
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
