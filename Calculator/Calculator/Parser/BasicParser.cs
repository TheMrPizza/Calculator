using System;
using Calculator.Exceptions;

namespace Calculator.Parser
{
    class BasicParser : IParser
    {
        public Expression Parse(string input)
        {
            input = input.Replace(" ", "");
            bool isNum1Found = false;
            for (int i = 0; i < input.Length; i++)
            {
                if (Char.IsDigit(input[i]))
                {
                    isNum1Found = true;
                }
                else if (isNum1Found)
                {
                    return SubstringInput(input, i);
                }
            }

            throw new ParsingException("Operation not found");
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
