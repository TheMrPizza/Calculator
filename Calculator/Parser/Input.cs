using System;
using System.Linq;
using Calculator.Arithmetic.Operations;
using Calculator.Exceptions;

namespace Calculator.Parser
{
    public class Input
    {
        public string Value { get; private set; }
        public string FullValue { get; }
        public bool IsBlocked { get; set; }
        private int _blockStartIndex { get; set; }
        private int _blockEndIndex { get; set; }

        public Input(string fullValue)
        {
            Value = RemoveSpaces(fullValue);
            FullValue = Value;
            IsBlocked = false;
            _blockStartIndex = 0;
            _blockEndIndex = 0;
        }

        public void Block(int startIndex, int endIndex)
        {
            Value = FullValue.Remove(startIndex, endIndex - startIndex + 1);
            IsBlocked = true;
            _blockStartIndex = startIndex;
            _blockEndIndex = endIndex;
        }

        public int FindOperationIndex(IOperation operation)
        {
            for (int i = 0; i < Value.Length; i++)
            {
                if (Value.Substring(i).StartsWith(operation.Sign))
                {
                    if (IsOperand(operation, i))
                    {
                        return GetFullIndex(i);
                    }
                }
            }

            return -1;
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

        private int GetFullIndex(int index)
        {
            if (!IsBlocked || index < _blockStartIndex)
            {
                return index;
            }

            return index + (_blockEndIndex - _blockStartIndex + 1);
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
                    return IsDigitOrSign(index + 1);
                }

                return char.IsDigit(Value[index]);
            }

            return false;
        }

        private string RemoveSpaces(string fullInput)
        {
            return fullInput.Replace(" ", string.Empty);
        }
    }
}
