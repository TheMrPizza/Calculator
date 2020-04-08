using System;
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

        public int FindOperationIndex(IOperation operation)
        {
            for (int i = 0; i < Value.Length; i++)
            {
                if (Value.Substring(i).StartsWith(operation.Sign))
                {
                    if (IsOperand(operation, i))
                    {
                        return Blocker.GetFullIndex(i);
                    }
                }
            }

            return -1;
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
                    return false;
                }
            }

            return true;
        }

        private bool IsDigitOrSign(int index)
        {
            if (index >= 0 && index < Value.Length)
            {
                if (Value[index] == '-')
                {
                    if (index + 1 < Value.Length)
                    {
                        return char.IsDigit(Value[index + 1]);
                    }

                    return false;
                }

                return char.IsDigit(Value[index]);
            }

            return false;
        }

        private string RemoveSpaces(string input)
        {
            return input.Replace(" ", string.Empty);
        }
    }
}
