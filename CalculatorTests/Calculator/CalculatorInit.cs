using Calculator.IO;
using Calculator.Parser;
using Calculator.Solver;

namespace Calculator.Tests
{
    public class CalculatorInit
    {
        public Calculator Init()
        {
            ConsoleIO consoleIO = new ConsoleIO();
            TreeParser parser = new TreeParser();
            TreeSolver solver = new TreeSolver();
            return new Calculator(consoleIO, parser, solver);
        }
    }
}
