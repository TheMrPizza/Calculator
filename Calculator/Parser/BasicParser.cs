using System;
using Calculator.Arithmetic;
using Calculator.Arithmetic.Operations;
using Calculator.Exceptions;

namespace Calculator.Parser
{
    public class BasicParser : IParser
    {
        public Input Input { get; set; }
        public ArithmeticUnit ArithmeticUnit { get; set; }

        public BasicParser(ArithmeticUnit arithmeticUnit)
        {
            Input = null;
            ArithmeticUnit = arithmeticUnit;
        }

        public Expression Parse(string input)
        {
            Input = new Input(input);
            foreach (IOperation operation in ArithmeticUnit.Operations)
            {
                int operationIndex = input.IndexOf(operation.Sign);
                if (operationIndex != -1)
                {
                    return SubstringInput(input, operation.Sign, operationIndex);
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
