using System.Collections.Generic;
using Calculator.IO;
using Calculator.Exceptions;
using Calculator.Parser;

namespace Calculator.Calculator
{
    public abstract class CalculatorBase
    {
        public delegate double Operation(double num1, double num2);

        public CalculatorBase(ArithmeticUnit arithmeticUnit, IStreamIO streamIO, IParser parser)
        {
            ArithmeticUnit = arithmeticUnit;
            Operations = new Dictionary<char, Operation>();
            StreamIO = streamIO;
            Parser = parser;
        }

        public ArithmeticUnit ArithmeticUnit { get; set; }
        public Dictionary<char, Operation> Operations { get; set; }
        public IStreamIO StreamIO { get; set; }
        public IParser Parser { get; set; }


        public abstract double Calc(Expression exp);

        public abstract void InitOperations();

        public void Start()
        {
            InitOperations();
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
