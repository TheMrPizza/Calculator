using Calculator.Arithmetic.Operations;

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

        public void Unblock()
        {
            Value = FullInput;
            IsBlocked = false;
            _blockStartIndex = 0;
            _blockEndIndex = 0;
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
            return IsDigitOrSign(index - 1) && IsDigitOrSign(index + operation.Sign.Length);
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
