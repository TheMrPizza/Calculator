using System.Collections.Generic;

namespace Calculator.Parser
{
    public interface IParser
    {
        Expression Parse(string input, char[] operations);
    }
}
