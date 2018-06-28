using System;

namespace _01_censorship
{
    class Censorship
    {
        static void Main()
        {
            var censor = Console.ReadLine();
            var text = Console.ReadLine();

            var censoredText = text.Replace(censor, new string('*', censor.Length));
            Console.WriteLine(censoredText);
        }
    }
}
