using Calculator.Arithmetic.Operations;

namespace Calculator.Parser
{
    public class Input
    {
        public string Value { get; private set; }
        private string _fullInput { get; }
        private bool _isBlocked { get; set; }
        private int _blockStartIndex { get; set; }
        private int _blockEndIndex { get; set; }


        public Input(string fullInput)
        {
            Value = RemoveSpaces(fullInput);
            _fullInput = Value;
            _isBlocked = false;
            _blockStartIndex = 0;
            _blockEndIndex = 0;
        }

        public void Block(int startIndex, int endIndex)
        {
            Value = _fullInput.Remove(startIndex, endIndex - startIndex + 1);
            _isBlocked = true;
            _blockStartIndex = startIndex;
            _blockEndIndex = endIndex;
        }

        public void Unblock()
        {
            Value = _fullInput;
            _isBlocked = false;
            _blockStartIndex = 0;
            _blockEndIndex = 0;
        }

        public int FindOperationIndex(IOperation operation)
        {
            int index = _fullInput.IndexOf(operation.Sign);
            if (!_isBlocked)
            {
                return index;
            }

            if (index == -1 || (index >= _blockStartIndex && index <= _blockEndIndex))
            {
                return -1;
            }
            
            if (index < _blockStartIndex)
            {
                return index;
            }

            return index - (_blockEndIndex - _blockStartIndex + 1);
        }

        private string RemoveSpaces(string fullInput)
        {
            return fullInput.Replace(" ", string.Empty);
        }
    }
}
