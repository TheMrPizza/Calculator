using System;
using Calculator.Exceptions;

namespace Calculator.Parser
{
    public partial class Input
    {

        public bool IsPrevOperandCorrect(int index)
        {
            return IsOperand(index - 1);
        }

        public bool IsNextOperandCorrect(int index)
        {
            return IsOperand(index + 1) || IsOperand(index + 2);
        }

        public string RemoveSpaces(string input)
        {
            return input.Replace(" ", string.Empty);
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

        private bool IsOperand(int index)
        {
            try
            {
                return double.TryParse(Value.Substring(index, 1), out _)
                    || _filteredValue[index] == _filterSign;
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
    }
}
