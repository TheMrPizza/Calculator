using Calculator.Arithmetic;

namespace Calculator.Solver
{
    public class BasicSolver : SolverBase
    {
        public BasicSolver()
        {
            ArithmeticUnit = new ArithmeticUnit();
        }

        public override double Solve(Expression exp)
        {
            Operation operation = GetOperationBySign(exp.Value);
            double num1 = double.Parse(exp.Left.Value);
            double num2 = double.Parse(exp.Right.Value);
            return operation.Func(num1, num2);
        }
    }
}
