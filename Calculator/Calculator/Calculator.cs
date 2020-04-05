using Calculator.IO;
using Calculator.Exceptions;
using Calculator.Parser;

namespace Calculator
{
    public class Calculator
    {
        public Calculator(ArithmeticUnit arithmeticUnit, IStreamIO streamIO, IParser parser)
        {
            ArithmeticUnit = arithmeticUnit;
            StreamIO = streamIO;
            Parser = parser;
        }

        public ArithmeticUnit ArithmeticUnit { get; set; }

        public IStreamIO StreamIO { get; set; }

        public IParser Parser { get; set; }

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
                Expression exp = Parser.Parse(input);
                string result = Calc(exp).ToString();
                StreamIO.Write(result);
            }
            catch (CalculatorExcpetion e)
            {
                StreamIO.Write(e.Message);
            }
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
                    throw new CalculatorExcpetion("Operation does not exist");
            }
        }
    }
}
