using System;
using Calculator;
using Calculator.IO;

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
            return new Calculator(arithmeticUnit, consoleIO);
        }
    }
}
