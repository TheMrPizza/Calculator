using Calculator.IO;
using Calculator.Parser;
using Calculator.Arithmetic;

namespace Calculator.Tests
{
    public class CalculatorInit
    {
        public CalculatorInit()
        {

        }

        public Calculator Init()
        {
            ConsoleIO consoleIO = new ConsoleIO();
            BasicParser parser = new BasicParser();
            BasicSolver solver = new BasicSolver();
            return new Calculator(consoleIO, parser, solver);
        }
    }
}
