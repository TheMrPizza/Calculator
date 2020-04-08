using Calculator.Arithmetic;

namespace Calculator.Parser
{
    public interface IParser
    {
        Input Input { get; set; }
        ArithmeticUnit ArithmeticUnit { get; set; }

        Expression Parse(string input);
    }
}
