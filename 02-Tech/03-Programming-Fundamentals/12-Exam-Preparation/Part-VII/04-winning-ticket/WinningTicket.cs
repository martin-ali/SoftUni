using System;
using System.IO;
using System.Text.RegularExpressions;

namespace _04_winning_ticket
{
    class WinningTicket
    {
        static void Main()
        {
#if DEBUG
            Console.SetIn(new StreamReader("test.txt"));
#endif

            var sixToNine = @"{6,9}";
            var group = $@"(@{sixToNine}|#{sixToNine}|\${sixToNine}|\^{sixToNine})";
            var winningTicketPattern = new Regex($@"({group}).*\1");
            var twenty = @"{20}";
            var jackpotTicketPattern = new Regex($@"@{twenty}|#{twenty}|\${twenty}|\^{twenty}");
            var tickets = Regex.Split(Console.ReadLine(), @"\s*,\s*");

            foreach (var ticket in tickets)
            {
                var jackpotTicket = jackpotTicketPattern.Match(ticket);
                var winningTicket = winningTicketPattern.Match(ticket);

                if (ticket.Length != 20)
                {
                    Console.WriteLine("invalid ticket");
                }
                else if (jackpotTicket.Success)
                {
                    Console.WriteLine($"ticket \"{ticket}\" - 10{jackpotTicket.Value[0]} Jackpot!");
                }
                else if (winningTicket.Success)
                {
                    int length = Math.Min(winningTicket.Groups[2].Length, winningTicket.Groups[1].Length);
                    Console.WriteLine($"ticket \"{ticket}\" - {length}{winningTicket.Groups[2].Value[0]}");
                }
                else
                {
                    Console.WriteLine($"ticket \"{ticket}\" - no match");
                }
            }
        }
    }
}
/*

Cash$$$$$$Ca$$$$$$sh

$$$$$$$$$$$$$$$$$$$$ , aabb , th@@@@@@eemo@@@@@@ey

validticketnomatch:(

123#######1########2, 1234######12^^^^^^^3, ^^^^^@@@@@^^^^@@@@@@

$$$$$$$$$$$$$$$$$$$$

Cash$$$$$$Ca$$$$$$sh

th@@@@@@@emo@@@@@@ey

$$$$$$$^$$$$$^$$$$$$, ^$$$$$$$$$$$$$$$$$$^

 */
