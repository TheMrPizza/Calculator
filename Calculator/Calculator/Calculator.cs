using Calculator.IO;
using Calculator.Parser;
using Calculator.Solver;
using Calculator.Exceptions;

namespace Calculator
{
    public class Calculator
    {
        public IStreamIO StreamIO { get; set; }
        public IParser Parser { get; set; }
        public SolverBase Solver { get; set; }

        public Calculator(IStreamIO streamIO, IParser parser, SolverBase solver)
        {
            StreamIO = streamIO;
            Parser = parser;
            Solver = solver;
        }

        public void Run()
        {
            while (true)
            {
                string input = StreamIO.Read();
                Answer(input);
            }
        }

        public void Answer(string input)
        {
            try
            {
                Expression exp = Parser.Parse(input, Solver.ArithmeticUnit.Operations);
                string result = Solver.Solve(exp).ToString();
                StreamIO.Write(result);
            }
            catch (CalculatorExcpetion e)
            {
                StreamIO.Write(e.Message);
            }
        }
    }
}
