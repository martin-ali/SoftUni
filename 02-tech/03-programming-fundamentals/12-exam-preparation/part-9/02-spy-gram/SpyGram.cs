using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace _02_spy_gram
{
    class SpyGram
    {
        static void Main()
        {
            var validationPattern = @"^TO: ([A-Z]+); MESSAGE: .+;$";
            var privateKey = Console.ReadLine().Select(character => character - 48).ToArray();
            var pendingMessages = new List<(string sender, string text)>();

            for (var clearTextMessage = Console.ReadLine(); clearTextMessage != "END"; clearTextMessage = Console.ReadLine())
            {
                var messageIsValid = Regex.Match(clearTextMessage, validationPattern);

                if (messageIsValid.Success == false)
                {
                    continue;
                }

                var encryptedMessage = string.Empty;
                for (int letterIndex = 0, keyIndex = 0; letterIndex < clearTextMessage.Length; letterIndex++, keyIndex++)
                {
                    if (keyIndex >= privateKey.Length) keyIndex = 0;
                    encryptedMessage += (char)(clearTextMessage[letterIndex] + privateKey[keyIndex]);
                }

                pendingMessages.Add((messageIsValid.Groups[1].Value, encryptedMessage));
            }

            var orderedPendingMessages = pendingMessages.OrderBy(message => message.sender);
            foreach (var message in orderedPendingMessages)
            {
                Console.WriteLine(message.text);
            }
        }
    }
}
/*

123
hello

13234
TO: GRIM; MESSAGE: hello;
TO: ARCHER; MESSAGE: sneak around it;
END

142325555
TO: KOBIN; MESSAGE: one two three;
TO: KESTREL; MESSAGE: affirmative;
T: REGAN; MESSAGE: help me;
TO: TOMCLANCY; MESSAGE: let's get to work;
TO: kestrel; MESSAGE: affirmative;
END

82738
TO: ARCHER; MESSAGE: affirmative;
FROM: SAM; MESSAGE: i'm pinned down;
TO: SAM; MESSAGE: 55% done;
FROM: SAM; MESSAGE: infiltrate the storage facility;
END

 */
