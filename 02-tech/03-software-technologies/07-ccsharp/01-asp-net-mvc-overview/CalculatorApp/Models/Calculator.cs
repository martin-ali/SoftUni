using System;
using System.Collections.Generic;

namespace CalculatorApp.Models
{
    public class Calculator
    {
        public Calculator() { }

        public Calculator(decimal leftOperand, decimal rightOperand, char @operator)
        {
            LeftOperand = leftOperand;
            RightOperand = rightOperand;
            Operator = @operator;
        }

        public decimal LeftOperand { get; set; }

        public decimal RightOperand { get; set; }

        public char Operator { get; set; }

        public decimal Result { get; set; } = 0;

        public void CalculateResult()
        {
            var actions = new Dictionary<char, Func<decimal, decimal, decimal>>
            {
                ['+'] = (a, b) => a + b,
                ['-'] = (a, b) => a - b,
                ['*'] = (a, b) => a * b,
                ['/'] = (a, b) => a / b
            };

            if (actions.ContainsKey(Operator)) Result = actions[Operator](LeftOperand, RightOperand);
        }
    }
}