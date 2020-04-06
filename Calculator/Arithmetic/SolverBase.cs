using System.Collections.Generic;
using Calculator.Exceptions;

namespace Calculator.Arithmetic
{
    public abstract class SolverBase
    {
        public delegate double Operation(double num1, double num2);

        public ArithmeticUnit ArithmeticUnit { get; set; }
        public Dictionary<string, Operation> Operations { get; set; }

        public abstract double Solve(Expression exp);
    }
}
