namespace Calculator.Arithmetic
{
    public abstract class SolverBase
    {
        public ArithmeticUnit ArithmeticUnit { get; set; }
        public abstract double Solve(Expression exp);
    }
}
