using System.Linq;
using Calculator.Arithmetic;
using Calculator.Arithmetic.Operations;

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

        public IOperation GetOperationByName(string name)
        {
            return ArithmeticUnit.Operations.Where(operation => operation.Name == name).First();
        }
    }
}
