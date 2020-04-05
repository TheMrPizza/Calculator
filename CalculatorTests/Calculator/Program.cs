using Calculator.IO;
using Calculator.Parser;
using Calculator.Calculator;

namespace Calculator.Tests
{
    class Program
    {
        static void Main(string[] args)
        {
            BasicCalculator calc = InitCalc();
            calc.Start();
        }

        public static BasicCalculator InitCalc()
        {
            ArithmeticUnit arithmeticUnit = new ArithmeticUnit();
            ConsoleIO consoleIO = new ConsoleIO();
            BasicParser parser = new BasicParser();
            return new BasicCalculator(arithmeticUnit, consoleIO, parser);
        }
    }
}
