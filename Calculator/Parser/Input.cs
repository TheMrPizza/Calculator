using System;
using Calculator.Arithmetic.Operations;
using Calculator.Exceptions;

namespace Calculator.Parser
{
    public class Input
    {
        public string Value { get; private set; }
        public bool IsBlocked { get; set; }
        public string FullInput { get; }
        private int _blockStartIndex { get; set; }
        private int _blockEndIndex { get; set; }

        public Input(string fullInput)
        {
            Value = RemoveSpaces(fullInput);
            FullInput = Value;
            IsBlocked = false;
            _blockStartIndex = 0;
            _blockEndIndex = 0;
        }

        public void Block(int startIndex, int endIndex)
        {
            Value = FullInput.Remove(startIndex, endIndex - startIndex + 1);
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
            bool prev = index == 0 || IsDigitOrSign(index - 1);
            bool next = index == Value.Length - 1 || IsDigitOrSign(index + operation.Sign.Length);
            return prev && next;
        }

        private bool IsDigitOrSign(int index)
        {
            if (index >= 0 && index < Value.Length)
            {
                return char.IsDigit(Value[index]) || Value[index] == '-';
            }

            return false;
        }

        private string RemoveSpaces(string fullInput)
        {
            return fullInput.Replace(" ", string.Empty);
        }
    }
}
