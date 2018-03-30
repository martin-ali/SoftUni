using System;
using System.Text.RegularExpressions;

namespace _03_text_filter
{
    class Program
    {
        static void Main()
        {
            var forbiddenWords = Console.ReadLine().Split(new string[] { ", " }, StringSplitOptions.RemoveEmptyEntries);
            var text = Console.ReadLine();

            foreach (var forbiddenWord in forbiddenWords)
            {
                var censor = new String('*', forbiddenWord.Length);
                var textChunks = text.Split(new string[] { forbiddenWord }, StringSplitOptions.None);
                text = String.Join(censor, textChunks);
            }

            Console.WriteLine(text);
        }
    }
}
// It is not Linux, it is GNU/Linux. Linux is merely the kernel, while GNU adds the functionality. Therefore we owe it to them by calling the OS GNU/Linux! Sincerely, a Windows client