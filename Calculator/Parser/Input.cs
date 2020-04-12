using System;
using System.Collections.Generic;
using Calculator.Arithmetic.Operations;
using Calculator.Exceptions;

namespace Calculator.Parser
{
    public class Input
    {
        public string Value { get; }
        public InputUtils Utils { get; }
        public string FilteredValue { get; set; }
        public char FilterSign { get; }

        public Input(string value)
        {
            Utils = new InputUtils(this);
            Value = Utils.RemoveSpaces(value);
            FilteredValue = Value;
            FilterSign = '\0';
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
            string start = FilteredValue.Substring(0, startIndex);
            string middle = new string(FilterSign, endIndex - startIndex + 1);
            string end = FilteredValue.Substring(endIndex + 1);
            FilteredValue = start + middle + end;
        }

        public void CheckIfNumber()
        {
            try
            {
                if (double.Parse(Value).ToString() != Value)
                {
                    throw new FormatException();
                }
            }
            catch (FormatException)
            {
                throw new ParsingException("Cannot parse the expression");
            }
        }

        private int FindRTL(IOperation operation, List<IOperation> allOperations)
        {
            int minIndex = 0;
            for (int i = 0; i < FilteredValue.Length; i++)
            {
                if (i >= minIndex && FilteredValue.Substring(i).StartsWith(operation.Sign)
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

        private int FindLTR(IOperation operation, List<IOperation> allOperations)
        {
            int maxIndex = FilteredValue.Length;
            for (int i = FilteredValue.Length; i >= 0; i--)
            {
                if (i <= maxIndex && FilteredValue.Substring(i).StartsWith(operation.Sign)
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

        private int MaxMatchingOperationLength(int index, List<IOperation> allOperations)
        {
            int maxLength = 0;
            for (int i = 0; i < allOperations.Count; i++)
            {
                if (FilteredValue.Substring(index).StartsWith(allOperations[i].Sign))
                {
                    if (allOperations[i].Sign.Length > maxLength)
                    {
                        maxLength = allOperations[i].Sign.Length;
                    }
                }
            }

            return maxLength;
        }
    }
}
