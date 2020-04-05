using System;
using Calculator.IO;

namespace Calculator
{
    public class Calculator
    {
        public Calculator(ArithmeticUnit arithmeticUnit, IStreamIO streamIO)
        {
            ArithmeticUnit = arithmeticUnit;
            StreamIO = streamIO;
        }

        public ArithmeticUnit ArithmeticUnit { get; set; }

        public IStreamIO StreamIO { get; set; }

        public void Start()
        {
            while(true)
            {
                string input = StreamIO.Read();
                string result = Solve(input);
                StreamIO.Write(result);
            }
        }

        public string Solve(string input)
        {
            Expression exp = Parse(input);
            return Calc(exp).ToString();
        }

        public Expression Parse(string input)
        {
            input = input.Replace(" ", "");
            for (int i = 0; i < input.Length; i++)
            {
                if (!Char.IsDigit(input[i]))
                {
                    double num1 = double.Parse(input.Substring(0, i));
                    double num2 = double.Parse(input.Substring(i + 1));
                    return new Expression(num1, num2, input[i]);
                }
            }

            return null;
        }

        public double Calc(Expression exp)
        {
            switch (exp.Operation)
            {
                case '+':
                    return ArithmeticUnit.Add(exp.Num1, exp.Num2);
                case '-':
                    return ArithmeticUnit.Sub(exp.Num1, exp.Num2);
                case '*':
                    return ArithmeticUnit.Mul(exp.Num1, exp.Num2);
                case '/':
                    return ArithmeticUnit.Mul(exp.Num1, exp.Num2);
            }

            return 0;
        }
    }
}
