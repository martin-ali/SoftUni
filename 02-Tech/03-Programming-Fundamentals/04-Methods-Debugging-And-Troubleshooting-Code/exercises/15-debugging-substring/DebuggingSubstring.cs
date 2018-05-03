using System;

namespace _15_debugging_substring
{
    class DebuggingSubstring
    {
        public static void Main()
        {
            string text = Console.ReadLine();
            int count = int.Parse(Console.ReadLine());

            const char Search = 'p';
            bool hasMatch = false;

            for (int index = 0; index < text.Length; index++)
            {
                var currentChar = text[index];
                if (currentChar == Search)
                {
                    hasMatch = true;

                    int length = count + 1;

                    if ((length + index) > text.Length)
                    {
                        length = text.Length - index;
                    }

                    string matchedString = text.Substring(index, length);
                    Console.WriteLine(matchedString);
                    index += count;
                }
            }

            if (!hasMatch)
            {
                Console.WriteLine("no");
            }
        }
    }
}
