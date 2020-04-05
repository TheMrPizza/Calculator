using System;
using Calculator.IO;
using Calculator.Exceptions;

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
                Solve(input);
            }
        }

        public void Solve(string input)
        {
            try
            {
                Expression exp = Parse(input);
                string result = Calc(exp).ToString();
                StreamIO.Write(result);
            }
            catch (CalculatorExcpetion e)
            {
                StreamIO.Write(e.Message);
            }
        }

        public Expression Parse(string input)
        {
            input = input.Replace(" ", "");
            for (int i = 0; i < input.Length; i++)
            {
                if (!Char.IsDigit(input[i]))
                {
                    try
                    {
                        double num1 = double.Parse(input.Substring(0, i));
                        double num2 = double.Parse(input.Substring(i + 1));
                        return new Expression(num1, num2, input[i]);
                    }
                    catch (FormatException)
                    {
                        throw new ParsingException("Expression not found");
                    }
                }
            }

            throw new ParsingException("Operation not found");
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
                    return ArithmeticUnit.Div(exp.Num1, exp.Num2);
 
                default:
                    throw new ParsingException("Operation does not exist");
            }
        }
    }
}
