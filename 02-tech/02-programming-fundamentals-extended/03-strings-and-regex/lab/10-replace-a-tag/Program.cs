using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace _10_replace_a_tag
{
    class Program
    {
        private static string aTagPattern = @"<a ?(.*)>(.*)<\/a>";

        static void Main()
        {
            // WTF - Why per-line basis?
            var line = Console.ReadLine();
            while (line != "end")
            {
                Console.WriteLine(ReplaceInstance(line));
                line = Console.ReadLine();
            }
        }

        private static string ReplaceStatic(string html)
        {
            var modifiedHtml = Regex.Replace(html, aTagPattern, match => "[URL " + match.Groups[1].Value.Trim() + "]" + match.Groups[2].Value.Trim() + "[/URL]");
            return modifiedHtml;
        }

        private static string ReplaceInstance(string html)
        {
            var urlTagPattern = @"[URL $1]$2[/URL]";

            var rex = new Regex(aTagPattern);
            var modifiedHtml = rex.Replace(html, urlTagPattern);

            return modifiedHtml;
        }

        private static string ReplaceWithReplace(string html)
        {
            return html
                    .Replace("<a ", "[URL ")
                    .Replace("<a", "[URL")
                    .Replace("</a>", "[/URL]")
                    .Replace("\">", "\"]");
        }
    }
}
// <ul>
// 	<li>
// 		<a href="http://softuni.bg">SoftUni</a>
// 	</li>
// </ul>

// var html = Console.ReadLine().Replace("end", "");
// var html = "<ul><li><a class=\"core\" href=\"http://softuni.bg\">SoftUni</a></li></ul>";
//             var html = @"<ul>
// 	<li>
// 		<a href=""http://softuni.bg"">SoftUni</a>
// 	</li>
// </ul>";