namespace Calculator.Arithmetic.Operations
{
    public class SubInput
    {
        public string Value { get; }
        public string Input { get; }
        public int StartIndex { get; }

        public SubInput(string input, int startIndex, int endIndex)
        {
            Value = input.Substring(startIndex, endIndex - startIndex);
            Input = input;
            StartIndex = startIndex;
        }

        public SubInput(string input)
        {
            Value = input;
            Input = input;
            StartIndex = 0;
        }
    }
}
