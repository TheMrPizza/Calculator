using System;
using System.Linq;
using Calculator.Exceptions;

namespace Calculator.Parser
{
    public class BasicParser : IParser
    {
        public Expression Parse(string input, string[] operations)
        {
            input = input.Replace(" ", string.Empty);
            foreach (string operation in operations)
            {
                int operationIndex = input.IndexOf(operation);
                if (operationIndex != -1)
                {
                    return SubstringInput(input, operation, operationIndex);
                }
            }

            throw new OperationException("Operation not found");
        }

        private Expression SubstringInput(string input, string operation, int operationIndex)
        {
            try
            {
                Expression right = new Expression(input.Substring(operationIndex + operation.Length));
                Expression left = new Expression(input.Substring(0, operationIndex));
                return new Expression(operation, right, left);
            }
            catch (FormatException)
            {
                throw new ParsingException("Cannot parse the expression");
            }
        }
    }
}
