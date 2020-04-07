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
            return HandleInput();
        }

        public Expression HandleInput()
        {
            foreach (IOperation operation in ArithmeticUnit.Operations)
            {
                int operationIndex = Input.FindOperationIndex(operation);
                if (operationIndex != -1)
                {
                    if (TryBlock(operation, operationIndex))
                    {
                        return HandleInput();
                    }

                    return ParseOperation(operation, operationIndex);
                }
            }

            Input.CheckIfNumber();
            return new Expression(Input.FullInput);
        }

        public Expression ParseOperation(IOperation operation, int operationIndex)
        {
            Expression exp = operation.Parse(Input.FullInput, operationIndex);
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

        public bool TryBlock(IOperation operation, int operationIndex)
        {
            if (operation is IBlockable)
            {
                if ((operation as IBlockable).Block(Input, operationIndex))
                {
                    return true;
                }
            }

            return false;
        }
    }
}
