using Calculator.Arithmetic;
using Calculator.Arithmetic.Operations;

namespace Calculator.Solver
{
    public class BasicSolver : SolverBase
    {
        public BasicSolver(ArithmeticUnit arithmeticUnit) : base(arithmeticUnit)
        {
            
        }

        public override double Solve(Expression exp)
        {
            IOperation operation = GetOperationBySign(exp.Value);
            double num1 = double.Parse(exp.Left.Value);
            double num2 = double.Parse(exp.Right.Value);
            return operation.Operate(num1, num2);
        }
    }
}
