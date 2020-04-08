using System;
using System.Collections.Generic;
using Calculator.Arithmetic.Operations;
using Calculator.Exceptions;

namespace Calculator.Parser
{
    public class Input
    {
        public string Value { get; private set; }
        public string FullValue { get; }
        public Blocker Blocker { get; }

        public Input(string fullValue)
        {
            Value = RemoveSpaces(fullValue);
            FullValue = Value;
            Blocker = new Blocker();
        }

        public int FindOperationIndex(IOperation operation, List<IOperation> allOperations)
        {
            for (int i = 0; i < Value.Length; i++)
            {
                if (Value.Substring(i).StartsWith(operation.Sign))
                {
                    if (IsMaxMatchingOperation(i, operation, allOperations))
                    {
                        return Blocker.GetFullIndex(i);
                    }
                }
            }

            return -1;
        }

        private bool IsMaxMatchingOperation(int index, IOperation operation, List<IOperation> allOperations)
        {
            IOperation maxOperation = operation;
            for (int i = 0; i < allOperations.Count; i++)
            {
                if (Value.Substring(index).StartsWith(allOperations[i].Sign))
                {
                    if (allOperations[i].Sign.Length > maxOperation.Sign.Length)
                    {
                        maxOperation = allOperations[i];
                    }
                }
            }

            return maxOperation == operation;
        }

        public void Block(int startIndex, int endIndex)
        {
            Value = FullValue.Remove(startIndex, endIndex - startIndex + 1);
            Blocker.Block(startIndex, endIndex);
        }

        public void CheckIfNumber()
        {
            try
            {
                double.Parse(Value);
            }
            catch (FormatException)
            {
                throw new ParsingException("Cannot parse the expression");
            }
        }

        private bool IsOperand(IOperation operation, int index)
        {
            foreach (int operandIndex in operation.GetOperandsIndexes(index))
            {
                if (!IsDigitOrSign(operandIndex))
                {
                    Console.WriteLine(operandIndex);
                    return false;
                }
            }

            return true;
        }

        private bool IsDigitOrSign(int index)
        {
            if (index >= 0 && index < FullValue.Length)
            {
                if (FullValue[index] == '-')
                {
                    if (index + 1 < FullValue.Length)
                    {
                        return char.IsDigit(FullValue[index + 1]);
                    }

                    return false;
                }

                return char.IsDigit(FullValue[index]);
            }

            return false;
        }

        private string RemoveSpaces(string input)
        {
            return input.Replace(" ", string.Empty);
        }
    }
}
