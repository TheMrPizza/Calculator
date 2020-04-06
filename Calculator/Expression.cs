namespace Calculator
{
    public class Expression
    {
        public double Num1 { get; }
        public double Num2 { get; }
        public char Operation { get; }

        public Expression(double num1, double num2, char operation)
        {
            Num1 = num1;
            Num2 = num2;
            Operation = operation;
        }
    }
}
