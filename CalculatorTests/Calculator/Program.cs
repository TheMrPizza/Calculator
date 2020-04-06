namespace Calculator.Tests
{
    class Program
    {
        static void Main(string[] args)
        {
            CalculatorInit init = new CalculatorInit();
            Calculator calc = init.Init();
            calc.Run();
        }
    }
}
