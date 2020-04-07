using System.Collections.Generic;
using Calculator.Arithmetic;

namespace Calculator.Parser
{
    public interface IParser
    {
        Expression Parse(string input, List<Operation> operations);
    }
}
