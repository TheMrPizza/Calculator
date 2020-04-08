using System;
using System.Collections.Generic;
using Calculator.Arithmetic.Operations;
using Calculator.Exceptions;

namespace Calculator.Parser
{
    public class Input
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

        public int FindRTL(IOperation operation, List<IOperation> allOperations)
        {
            int minIndex = 0;
            for (int i = 0; i < _filteredValue.Length; i++)
            {
                if (i >= minIndex && _filteredValue.Substring(i).StartsWith(operation.Sign)
                    && operation.IsOperationCorrect(this, i))
                {
                    int maxLength = MaxMatchingOperationLength(i, allOperations);
                    if (operation.Sign.Length == maxLength)
                    {
                        return i;
                    }

                    minIndex = i + maxLength;
                }
            }

            return -1;
        }

        public int FindLTR(IOperation operation, List<IOperation> allOperations)
        {
            int maxIndex = _filteredValue.Length;
            for (int i = _filteredValue.Length; i >= 0; i--)
            {
                if (i <= maxIndex && _filteredValue.Substring(i).StartsWith(operation.Sign)
                    && operation.IsOperationCorrect(this, i))
                {
                    int maxLength = MaxMatchingOperationLength(i, allOperations);
                    if (operation.Sign.Length == maxLength)
                    {
                        return i;
                    }

                    maxIndex = i - maxLength;
                }
            }

            return -1;
        }

        public void Block(int startIndex, int endIndex)
        {
            string start = _filteredValue.Substring(0, startIndex);
            string middle = new string(_filterSign, endIndex - startIndex + 1);
            string end = _filteredValue.Substring(endIndex + 1);
            _filteredValue = start + middle + end;
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

        private int MaxMatchingOperationLength(int index, List<IOperation> allOperations)
        {
            int maxLength = 0;
            for (int i = 0; i < allOperations.Count; i++)
            {
                if (_filteredValue.Substring(index).StartsWith(allOperations[i].Sign))
                {
                    if (allOperations[i].Sign.Length > maxLength)
                    {
                        maxLength = allOperations[i].Sign.Length;
                    }
                }
            }

            return maxLength;
        }

        public bool IsPrevOperandCorrect(int index)
        {
            return IsOperand(index - 1);
        }

        public bool IsNextOperandCorrect(int index)
        {
            if (IsOperand(index + 1))
            {
                return true;
            }

            return IsOperand(index + 2);
        }

        private bool IsOperand(int index)
        {
            try
            {
                return double.TryParse(Value.Substring(index, 1), out _) || _filteredValue[index] == _filterSign;
            }
            catch (ArgumentOutOfRangeException)
            {
                return false;
            }
            catch (IndexOutOfRangeException)
            {
                return false;
            }
        }

        private string RemoveSpaces(string input)
        {
            return input.Replace(" ", string.Empty);
        }
    }
}
