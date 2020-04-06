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
                double num1 = double.Parse(input.Substring(0, operationIndex));
                double num2 = double.Parse(input.Substring(operationIndex + operation.Length));
                return new Expression(num1, num2, operation);
            }
            catch (FormatException)
            {
                throw new ParsingException("Cannot parse the expression");
            }
        }
    }
}
