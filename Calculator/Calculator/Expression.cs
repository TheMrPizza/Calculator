namespace Calculator
{
    public class Expression
    {
        public string Value { get; set; }
        public Expression Right { get; set; }
        public Expression Left { get; set; }

        public Expression(string value)
        {
            Value = value;
            Right = null;
            Left = null;
        }

        public Expression(string value, Expression right, Expression left)
        {
            Value = value;
            Right = right;
            Left = left;
        }
    }
}
