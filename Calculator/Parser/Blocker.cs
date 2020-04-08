namespace Calculator.Parser
{
    public class Blocker
    {
        public int StartIndex { get; set; }
        public int EndIndex { get; set; }
        public bool IsBlocked { get; set; }

        public Blocker()
        {
            StartIndex = 0;
            EndIndex = 0;
            IsBlocked = false;
        }

        public Blocker(int startIndex, int endIndex)
        {
            Block(startIndex, endIndex);
        }

        public void Block(int startIndex, int endIndex)
        {
            StartIndex = startIndex;
            EndIndex = endIndex;
            IsBlocked = true;
        }

        public int GetFullIndex(int index)
        {
            if (!IsBlocked || index < StartIndex)
            {
                return index;
            }

            return index + (EndIndex - StartIndex + 1);
        }

        public int GetRelativeIndex(int index)
        {
            if (!IsBlocked || index < StartIndex)
            {
                return index;
            }

            return index - (EndIndex - StartIndex + 1);
        }
    }
}
