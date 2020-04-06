namespace Calculator.Parser
{
    public interface IParser
    {
        Expression Parse(string input);
    }
}
