using Calculator.IO;
using Calculator.Exceptions;
using Calculator.Parser;

namespace Calculator.Calculator
{
    public class BasicCalculator : CalculatorBase
    {
        public BasicCalculator(ArithmeticUnit arithmeticUnit, IStreamIO streamIO, IParser parser)
            : base(arithmeticUnit, streamIO, parser)
        {
            Operations.Add('+', ArithmeticUnit.Add);
            Operations.Add('-', ArithmeticUnit.Sub);
            Operations.Add('*', ArithmeticUnit.Mul);
            Operations.Add('/', ArithmeticUnit.Div);
        }

        public override double Calc(Expression exp)
        {
            if (Operations.ContainsKey(exp.Operation))
            {
                Operation operation = Operations[exp.Operation];
                return operation(exp.Num1, exp.Num2);
            }

            throw new CalculatorExcpetion("Operation does not exist");
        }
    }
}
