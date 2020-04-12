using System.Collections.Generic;
using Calculator.Arithmetic.Operations;

namespace Calculator.Parser
{
    public partial class Input
    {
        public string Value { get; }
        private string _filteredValue { get; set; }
        private char _filterSign { get; }

        public Input(string value)
        {
            Value = RemoveSpaces(value);
            _filteredValue = Value;
            _filterSign = '\0';
        }

        public int FindOperationIndex(IOperation operation, List<IOperation> allOperations)
        {
            if (operation.IsRTL)
            {
                return FindRTL(operation, allOperations);
            }

            return FindLTR(operation, allOperations);
        }

        public void Block(int startIndex, int endIndex)
        {
            string start = _filteredValue.Substring(0, startIndex);
            string middle = new string(_filterSign, endIndex - startIndex + 1);
            string end = _filteredValue.Substring(endIndex + 1);
            _filteredValue = start + middle + end;
        }

        private int FindRTL(IOperation operation, List<IOperation> allOperations)
        {
            int minIndex = 0;
            for (int i = 0; i < _filteredValue.Length; i++)
            {
                if (i >= minIndex && _filteredValue.Substring(i).StartsWith(operation.Notation.Sign)
                    && operation.Notation.IsCorrect(this, i))
                {
                    int maxLength = MaxMatchingOperationLength(i, allOperations);
                    if (operation.Notation.Sign.Length == maxLength)
                    {
                        return i;
                    }

                    minIndex = i + maxLength;
                }
            }

            return -1;
        }

        private int FindLTR(IOperation operation, List<IOperation> allOperations)
        {
            int maxIndex = _filteredValue.Length;
            for (int i = _filteredValue.Length; i >= 0; i--)
            {
                if (i <= maxIndex && _filteredValue.Substring(i).StartsWith(operation.Notation.Sign)
                    && operation.Notation.IsCorrect(this, i))
                {
                    int maxLength = MaxMatchingOperationLength(i, allOperations);
                    if (operation.Notation.Sign.Length == maxLength)
                    {
                        return i;
                    }

                    maxIndex = i - maxLength;
                }
            }

            return -1;
        }

        private int MaxMatchingOperationLength(int index, List<IOperation> allOperations)
        {
            int maxLength = 0;
            for (int i = 0; i < allOperations.Count; i++)
            {
                if (_filteredValue.Substring(index).StartsWith(allOperations[i].Notation.Sign))
                {
                    if (allOperations[i].Notation.Sign.Length > maxLength)
                    {
                        maxLength = allOperations[i].Notation.Sign.Length;
                    }
                }
            }

            return maxLength;
        }
    }
}
