using System;

namespace Calculator.Arithmetic
{
    public class Operation
    {
        public string Sign { get; }
        public Func<double, double, double> Func { get; }

        public Operation(string sign, Func<double, double, double> func, int priority)
        {
            Sign = sign;
            Func = func;
        }
    }
}
