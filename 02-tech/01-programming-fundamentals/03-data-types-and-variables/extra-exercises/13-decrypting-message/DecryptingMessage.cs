using System;
using System.Text;

namespace _13_decrypting_message
{
    class DecryptingMessage
    {
        static void Main()
        {
            var key = int.Parse(Console.ReadLine());
            var numberOfLines = int.Parse(Console.ReadLine());
            var decryptedMessageBuilder = new StringBuilder();

            for (int current = 0; current < numberOfLines; current++)
            {
                var encryptedCharacter = char.Parse(Console.ReadLine());
                decryptedMessageBuilder.Append((char)(encryptedCharacter + key));
            }

            Console.WriteLine(decryptedMessageBuilder);
        }
    }
}
