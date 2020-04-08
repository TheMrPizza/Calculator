using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
            int minIndex = 0;
            for (int i = 0; i < _filteredValue.Length; i++)
            {
                if (i >= minIndex && _filteredValue.Substring(i).StartsWith(operation.Sign))
                {
                    IOperation maxMatching = MaxMatchingOperation(i, allOperations);
                    if (maxMatching == operation)
                    {
                        return i;
                    }

                    minIndex = i + maxMatching.Sign.Length;
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

        private IOperation MaxMatchingOperation(int index, List<IOperation> allOperations)
        {
            IOperation maxOperation = allOperations[0];
            int maxLength = 0;
            for (int i = 0; i < allOperations.Count; i++)
            {
                if (_filteredValue.Substring(index).StartsWith(allOperations[i].Sign))
                {
                    if (allOperations[i].Sign.Length > maxLength)
                    {
                        maxOperation = allOperations[i];
                        maxLength = allOperations[i].Sign.Length;
                    }
                }
            }

            return maxOperation;
        }

        private string RemoveSpaces(string input)
        {
            return input.Replace(" ", string.Empty);
        }
    }
}
