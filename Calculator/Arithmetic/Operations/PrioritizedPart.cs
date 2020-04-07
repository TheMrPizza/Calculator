namespace Calculator.Arithmetic.Operations
{
    public class PrioritizedPart
    {
        public int StartIndex { get; }
        public int EndIndex { get; }

        public PrioritizedPart(int startIndex, int endIndex)
        {
            StartIndex = startIndex;
            EndIndex = endIndex;
        }
    }
}
