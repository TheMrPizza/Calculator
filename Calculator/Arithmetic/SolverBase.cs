using System.Collections.Generic;
using Calculator.Exceptions;

namespace Calculator.Arithmetic
{
    public abstract class SolverBase
    {
        public delegate double Operation(double num1, double num2);

        public ArithmeticUnit ArithmeticUnit { get; set; }
        public Dictionary<char, Operation> Operations { get; set; }

        public double Solve(Expression exp)
        {
            if (Operations.ContainsKey(exp.Operation))
            {
                Operation operation = Operations[exp.Operation];
                return operation(exp.Num1, exp.Num2);
            }

            throw new OperationException("Operation does not exist");
        }
    }
}
