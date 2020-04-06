using Calculator.Arithmetic;

namespace Calculator.Solver
{
    public class TreeSolver : SolverBase
    {
        public TreeSolver()
        {
            ArithmeticUnit = new ArithmeticUnit();
        }

        public override double Solve(Expression exp)
        {
            if (exp.IsNumber())
            {
                return double.Parse(exp.Value);
            }

            Operation operation = GetOperationBySign(exp.Value);
            return operation.Func(Solve(exp.Left), Solve(exp.Right));
        }
    }
}
