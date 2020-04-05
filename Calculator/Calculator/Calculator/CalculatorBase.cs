using Calculator.IO;
using Calculator.Exceptions;
using Calculator.Parser;

namespace Calculator.Calculator
{
    public abstract class CalculatorBase
    {
        public CalculatorBase(ArithmeticUnit arithmeticUnit, IStreamIO streamIO, IParser parser)
        {
            ArithmeticUnit = arithmeticUnit;
            StreamIO = streamIO;
            Parser = parser;
        }

        public ArithmeticUnit ArithmeticUnit { get; set; }

        public IStreamIO StreamIO { get; set; }

        public IParser Parser { get; set; }


        public abstract double Calc(Expression exp);

        public void Start()
        {
            while (true)
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
    }
}
