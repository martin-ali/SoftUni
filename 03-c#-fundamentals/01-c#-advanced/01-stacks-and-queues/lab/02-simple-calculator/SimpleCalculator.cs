using System;
using System.Collections.Generic;
using System.Linq;

namespace _02_simple_calculator
{
    class SimpleCalculator
    {
        static void Main()
        {
            var expression = Console.ReadLine().Split().Reverse();
            var expressionMembers = new Stack<string>(expression);

            while (expressionMembers.Count > 1)
            {
                var firstNumber = int.Parse(expressionMembers.Pop());
                var mathOperator = expressionMembers.Pop();
                var secondNumber = int.Parse(expressionMembers.Pop());

                var result = 0;
                if (mathOperator == "+")
                {
                    result = firstNumber + secondNumber;
                }
                else
                {
                    result = firstNumber - secondNumber;
                }

                expressionMembers.Push(result.ToString());
            }

            Console.WriteLine(expressionMembers.Pop());

            // var sum = 0;
            // var isAddition = true;
            // foreach (var operand in expression)
            // {
            //     if (operand == "+")
            //     {
            //         isAddition = true;
            //     }
            //     else if (operand == "-")
            //     {
            //         isAddition = false;
            //     }
            //     else if (isAddition)
            //     {
            //         sum += int.Parse(operand);
            //     }
            //     else
            //     {
            //         sum -= int.Parse(operand);
            //     }
            // }

            // Console.WriteLine(sum);
        }
    }
}
