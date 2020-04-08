using Calculator.Arithmetic;
using Calculator.Arithmetic.Operations;

namespace Calculator.Solver
{
    public class TreeSolver : SolverBase
    {
        public TreeSolver(ArithmeticUnit arithmeticUnit) : base(arithmeticUnit)
        {

        }

        public override double Solve(Expression exp)
        {
            if (exp == null)
            {
                return 0;
            }

            if (exp.IsNumber())
            {
                return double.Parse(exp.Value);
            }

            IOperation operation = GetOperationByName(exp.Value);
            return operation.Operate(Solve(exp.Left), Solve(exp.Right));
        }
    }
}
