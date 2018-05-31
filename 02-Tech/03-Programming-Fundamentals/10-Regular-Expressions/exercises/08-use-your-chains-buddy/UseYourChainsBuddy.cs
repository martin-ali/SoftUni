using System;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace _08_use_your_chains_buddy
{
    class UseYourChainsBuddy
    {
        static void Main()
        {
            var input = Console.ReadLine();

            var result = new StringBuilder();
            var paragraphs = Regex.Matches(input, @"<p>(.+?)</p>");

            foreach (Match paragraph in paragraphs)
            {
                var decryptedParagraph = paragraph.Groups[1].Value;
                decryptedParagraph = Regex.Replace(decryptedParagraph, "[^a-z0-9]", " ");
                decryptedParagraph = Regex.Replace(decryptedParagraph, " +", " ");
                decryptedParagraph = string.Concat(decryptedParagraph.Select(c =>
                {
                    if ('a' <= c && c <= 'm')
                    {
                        return (char)(c + 13);
                    }
                    else if ('n' <= c && c <= 'z')
                    {
                        return (char)(c - 13);
                    }

                    return c;
                }));

                result.Append(decryptedParagraph);
            }

            Console.WriteLine(result.ToString());
        }
    }
}
/*

<html><head><title></title></head><body><h1>hello</h1><p>znahny!@#%&&&&****</p><div><button>dsad</button></div><p>grkg^^^^%%%)))([]12</p></body></html>

<html><head><title></title></head><body><h1>Intro</h1><ul><li>Item01</li><li>Item02</li><li>Item03</li></ul><p>jura qevivat va jrg fyvccrel fabjl</p><div><button>Click me, baby!</button></div><p> pbaqvgvbaf fabj  qpunvaf ner nofbyhgryl rffragvny sbe fnsr unaqyvat nygubhtu fabj punvaf znl ybbx </p><span>This manual is false, do not trust it! The illuminati wrote it down to trick you!</span><p>vagvzvqngvat gur onfvp vqrn vf ernyyl fvzcyr svg gurz bire lbhe gverf qevir sbejneq fybjyl naq gvtugra gurz hc va pbyq jrg</p><p> pbaqvgvbaf guvf vf rnfvre fnvq guna qbar ohg vs lbh chg ba lbhe gverf</p></body>

 */
