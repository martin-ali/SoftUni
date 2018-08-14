using System;
using System.Collections.Generic;

namespace _09_stack_fibonacci
{
    class StackFibonacci
    {
        static void Main()
        {
            var targetFibonacci = int.Parse(Console.ReadLine());

            var fibonacciStack = new Stack<long>();
            fibonacciStack.Push(0);
            fibonacciStack.Push(1);

            for (int i = 1; i < targetFibonacci; i++)
            {
                var oneFibonacciBack = fibonacciStack.Pop();
                var twoFibonacciBack = fibonacciStack.Peek();

                var currentFibonacci = oneFibonacciBack + twoFibonacciBack;

                fibonacciStack.Push(oneFibonacciBack);
                fibonacciStack.Push(currentFibonacci);
            }

            Console.WriteLine(fibonacciStack.Pop());
        }
    }
}
