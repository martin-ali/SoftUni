using System;
using System.Text.RegularExpressions;

namespace _03_anonymous_vox
{
    class AnonymousVox
    {
        static void Main()
        {
            var encryptedMessage = Console.ReadLine();
            var replacementValues = Console.ReadLine().Split(new char[] { '{', '}' }, StringSplitOptions.RemoveEmptyEntries);

            var current = 0;
            var end = replacementValues.Length;
            var decryptedMessage = Regex.Replace(encryptedMessage, @"([A-Za-z]+)(.+)(\1)", match =>
            {
                int index = current == end ? current : current++;
                var replacement = $"{match.Groups[1]}{replacementValues[index]}{match.Groups[1]}";

                return replacement;
            });

            Console.WriteLine(decryptedMessage);
        }
    }
}
/*

Hello_mister,_Hello
{ Jack }

ASD___asdfffasd
{this}{exam}{problem}{is}{boring}

Whatsup_ddd_sup
{Dude}

HeypalHey______how_ya_how_doin_how
{first}{second}

 */
