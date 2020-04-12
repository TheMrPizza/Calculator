using System;

namespace Calculator.Parser
{
    public class InputUtils
    {
        public Input Input { get; }

        public InputUtils(Input input)
        {
            Input = input;
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

        public string RemoveSpaces(string input)
        {
            return input.Replace(" ", string.Empty);
        }

        private bool IsOperand(int index)
        {
            try
            {
                return double.TryParse(Input.Value.Substring(index, 1), out _)
                    || Input.FilteredValue[index] == Input.FilterSign;
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
