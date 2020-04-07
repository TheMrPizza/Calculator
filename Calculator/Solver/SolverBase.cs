using System.Linq;
using Calculator.Arithmetic;

namespace Calculator.Solver
{
    public abstract class SolverBase
    {
        public ArithmeticUnit ArithmeticUnit { get; set; }

        public SolverBase(ArithmeticUnit arithmeticUnit)
        {
            ArithmeticUnit = arithmeticUnit;
        }

        public abstract double Solve(Expression exp);
        public Operation GetOperationBySign(string sign)
        {
            return ArithmeticUnit.Operations.Where(operation => operation.Sign == sign).First();
        }
    }
}
