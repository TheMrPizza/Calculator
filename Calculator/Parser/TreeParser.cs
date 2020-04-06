namespace Calculator.Parser
{
    public class TreeParser : IParser
    {
        public Expression Parse(string input, string[] operations)
        {
            foreach (string operation in operations)
            {
                int operationIndex = input.IndexOf(operation);
                if (operationIndex != -1)
                {
                    Expression right = Parse(input.Substring(0, operationIndex), operations);
                    Expression left = Parse(input.Substring(operationIndex + operation.Length), operations);
                    return new Expression(operation, right, left);
                }
            }

            input = input.Replace(" ", string.Empty);
            return new Expression(input);
        }
    }
}
