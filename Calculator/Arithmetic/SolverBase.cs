using System.Linq;

namespace Calculator.Arithmetic
{
    public abstract class SolverBase
    {
        public ArithmeticUnit ArithmeticUnit { get; set; }
        public abstract double Solve(Expression exp);

        public Operation GetOperationBySign(string sign)
        {
            return ArithmeticUnit.Operations.Where(operation => operation.Sign == sign).First();
        }
    }
}
