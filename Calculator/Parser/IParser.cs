using System.Collections.Generic;
using Calculator.Arithmetic.Operations;

namespace Calculator.Parser
{
    public interface IParser
    {
        Expression Parse(string input, List<IOperation> operations);
    }
}
