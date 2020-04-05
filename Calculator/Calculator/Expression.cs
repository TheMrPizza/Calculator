namespace Calculator
{
    public class Expression
    {
        public readonly double Num1;
        public readonly double Num2;
        public readonly char Operation;

        public Expression(double num1, double num2, char operation)
        {
            Num1 = num1;
            Num2 = num2;
            Operation = operation;
        }
    }
}
