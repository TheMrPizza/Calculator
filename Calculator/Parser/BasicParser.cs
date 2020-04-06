using System;
using System.Linq;
using Calculator.Exceptions;

namespace Calculator.Parser
{
    public class BasicParser : IParser
    {
        public Expression Parse(string input, char[] operations)
        {
            input = input.Replace(" ", string.Empty);
            for (int i = 0; i < input.Length; i++)
            {
                if (operations.Contains(input[i]))
                {
                    return SubstringInput(input, i);
                }
            }

            throw new OperationException("Operation not found");
        }

        private Expression SubstringInput(string input, int operationIndex)
        {
            try
            {
                double num1 = double.Parse(input.Substring(0, operationIndex));
                double num2 = double.Parse(input.Substring(operationIndex + 1));
                return new Expression(num1, num2, input[operationIndex]);
            }
            catch (FormatException)
            {
                throw new ParsingException("Cannot parse the expression");
            }
        }
    }
}
