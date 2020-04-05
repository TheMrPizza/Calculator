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

        }

        public override double Calc(Expression exp)
        {
            switch (exp.Operation)
            {
                case '+':
                    return ArithmeticUnit.Add(exp.Num1, exp.Num2);
                case '-':
                    return ArithmeticUnit.Sub(exp.Num1, exp.Num2);
                case '*':
                    return ArithmeticUnit.Mul(exp.Num1, exp.Num2);
                case '/':
                    return ArithmeticUnit.Div(exp.Num1, exp.Num2);
                default:
                    throw new CalculatorExcpetion("Operation does not exist");
            }
        }
    }
}
