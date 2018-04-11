using System;
using System.Collections.Generic;
using System.Linq;

namespace _02_hornet_armada
{
    class Program
    {
        private static int index = 0;

        private static string[] testInput = @"6
1 = BlackBeatles -> Soldier:2000
2 = BlackBeatles -> Worker:1000
1 = Red_Ones -> Soldier:10000
5 = Rm -> Soldier:30000
2 = Red_Ones -> Soldier:20000
10 = RND -> Soldier:100000
10\Soldier".Split(new char[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);

        static void Main()
        {

        }
    }
}
