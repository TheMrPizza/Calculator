﻿using System.Collections.Generic;

namespace Calculator.Arithmetic
{
    public class BasicSolver : SolverBase
    {
        public BasicSolver()
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
            Operation operation = Operations[exp.Value];
            double num1 = double.Parse(exp.Left.Value);
            double num2 = double.Parse(exp.Right.Value);
            return operation(num1, num2);
        }
    }
}
