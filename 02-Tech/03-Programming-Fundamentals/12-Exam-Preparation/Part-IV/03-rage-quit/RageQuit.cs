using System;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace _03_rage_quit
{
    class RageQuit
    {
        static void Main()
        {
            var message = Console.ReadLine();

            var builder = new StringBuilder();
            var finalMessage = Regex.Replace(message, @"(\D+?)(\d+)", m =>
            {
                builder.Clear();
                var element = m.Groups[1].Value.ToUpper();
                var repeats = int.Parse(m.Groups[2].Value);

                var replacement = string.Empty;
                for (int i = 0; i < repeats; i++)
                {
                    builder.Append(element);
                }

                return builder.ToString();
            });

            Console.WriteLine($"Unique symbols used: {finalMessage.Distinct().Count()}");
            Console.WriteLine(finalMessage);
        }
    }
}
/*

e-!btI17z=E:DMJ19U1Tvg VQ>11P"qCmo.-0YHYu~o%/%b.}a[=d15fz^"{0^/pg.Ft{W12`aD<l&$W&)*yF1WLV9_GmTf(d0($!$`e/{D'xi]-~17 *%p"%|N>zq@ %xBD18<Y(fHh`@gu#Z#p"Z<v13fI]':\Iz.17*W:\mwV`z-15g@hUYE{_$~}+X%*nytkW15

 */
