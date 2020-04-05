using Calculator.IO;
using Calculator.Parser;

namespace Calculator
{
    class Program
    {
        static void Main(string[] args)
        {
            Calculator calc = InitCalc();
            calc.Start();
        }

        public static Calculator InitCalc()
        {
            ArithmeticUnit arithmeticUnit = new ArithmeticUnit();
            ConsoleIO consoleIO = new ConsoleIO();
            BasicParser parser = new BasicParser();
            return new Calculator(arithmeticUnit, consoleIO, parser);
        }
    }
}
