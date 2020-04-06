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
    }
}
