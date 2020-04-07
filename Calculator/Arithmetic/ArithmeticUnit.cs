using System.Collections.Generic;
using Calculator.Arithmetic.Operations;

namespace Calculator.Arithmetic
{
    public class ArithmeticUnit
    {
        public List<IOperation> Operations { get; }

        public ArithmeticUnit()
        {
            // These operations will be solved by their order here
            Operations = new List<IOperation>
            {
                new Abs(),
                new Add(),
                new Sub(),
                new Mul(),
                new Div()
            };
        }
    }
}
