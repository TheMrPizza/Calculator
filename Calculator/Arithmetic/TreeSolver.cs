using System.Collections.Generic;

namespace Calculator.Arithmetic
{
    public class TreeSolver : SolverBase
    {
        public TreeSolver()
        {
            ArithmeticUnit = new ArithmeticUnit();
            Operations = new Dictionary<string, Operation>
            {
                { "+",  ArithmeticUnit.Add },
                { "-",  ArithmeticUnit.Sub },
                { "*",  ArithmeticUnit.Mul },
                { "/",  ArithmeticUnit.Div }
            };
        }

        public override double Solve(Expression exp)
        {
            if (exp.IsNumber())
            {
                return double.Parse(exp.Value);
            }

            Operation operation = Operations[exp.Value];
            return operation(Solve(exp.Left), Solve(exp.Right));
        }
    }
}
