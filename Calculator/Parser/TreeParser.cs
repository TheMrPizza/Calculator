using System;
using System.Collections.Generic;
using Calculator.Arithmetic;
using Calculator.Arithmetic.Operations;
using Calculator.Exceptions;

namespace Calculator.Parser
{
    public class TreeParser : IParser
    {
        public Input Input { get; set; }
        public ArithmeticUnit ArithmeticUnit { get; set; }

        public TreeParser(ArithmeticUnit arithmeticUnit)
        {
            Input = null;
            ArithmeticUnit = arithmeticUnit;
        }

        public Expression Parse(string input)
        {
            Input = new Input(input);
            foreach (IOperation operation in ArithmeticUnit.Operations)
            {
                int operationIndex = Input.FindOperationIndex(operation);
                if (operationIndex != -1)
                {
                    if (operation is IPrioritizable)
                    {
                        (operation as IPrioritizable).Prioritize(Input, operationIndex);
                    }
                    else
                    {
                        Input.Unblock();
                        return ParseOperation(operation, operationIndex);
                    }
                }
            }

            CheckIfNumber();
            return new Expression(Input.Value);
        }

        public Expression ParseOperation(IOperation operation, int operationIndex)
        {
            Expression exp = operation.Parse(Input.Value, operationIndex);
            if (exp.Right != null)
            {
                exp.Right = Parse(exp.Right.Value);
            }

            if (exp.Left != null)
            {
                exp.Left = Parse(exp.Left.Value);
            }

            return exp;
        }

        private void CheckIfNumber()
        {
            try
            {
                double.Parse(Input.Value);
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
