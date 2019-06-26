using System;
using System.Collections.Generic;
using System.Linq;

namespace _01_socks
{
    class Socks
    {
        static void Main()
        {
            var leftSocksData = Console.ReadLine()
                                    .Split()
                                    .Select(int.Parse);
            var leftSocks = new Stack<int>(leftSocksData);

            var rightSocksData = Console.ReadLine()
                                    .Split()
                                    .Select(int.Parse);
            var rightSocks = new Stack<int>(rightSocksData.Reverse());

            var pairs = new Queue<int>();
            while (leftSocks.Count > 0 && rightSocks.Count > 0)
            {
                var leftSock = leftSocks.Pop();
                var rightSock = rightSocks.Pop();

                if (leftSock > rightSock)
                {
                    var pair = leftSock + rightSock;

                    pairs.Enqueue(pair);
                }
                else if (rightSock > leftSock)
                {
                    rightSocks.Push(rightSock);
                }
                else
                {
                    leftSocks.Push(leftSock + 1);
                }
            }

            Console.WriteLine(pairs.Max());
            Console.WriteLine(string.Join(' ', pairs));
        }
    }
}