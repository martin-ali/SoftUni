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
            var a = this.LeftOperand;
            var b = this.RightOperand;

            var compute = new Dictionary<char, Func<decimal>>
            {
                ['+'] = () => a + b,
                ['-'] = () => a - b,
                ['*'] = () => a * b,
                ['/'] = () => a / b
            };

            if (compute.ContainsKey(Operator)) Result = compute[Operator]();
        }
    }
}