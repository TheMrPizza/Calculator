using Calculator.Parser;

namespace Calculator.Arithmetic.Notations
{
    public interface INotation
    {
        string Sign { get; }
        string Name { get; }

        Expression Parse(string input, int operationIndex);

        bool IsCorrect(Input input, int operationIndex);
    }
}
