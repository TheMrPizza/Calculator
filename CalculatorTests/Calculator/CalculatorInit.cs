using Calculator.IO;
using Calculator.Parser;
using Calculator.Solver;
using Calculator.Arithmetic;

namespace Calculator.Tests
{
    public class CalculatorInit
    {
        public Calculator Init()
        {
            ConsoleIO consoleIO = new ConsoleIO();
            TreeParser parser = new TreeParser();
            ArithmeticUnit arithmetic = new ArithmeticUnit();
            TreeSolver solver = new TreeSolver(arithmetic);
            return new Calculator(consoleIO, parser, solver);
        }
    }
}
