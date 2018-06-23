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

            var sixToNineTimes = @"{6,9}";
            var twentyTimes = @"{20}";
            var winningTicketPattern = new Regex($@"(@{sixToNineTimes}|#{sixToNineTimes}|\${sixToNineTimes}|\^{sixToNineTimes})");
            var jackpotTicketPattern = new Regex($@"@{twentyTimes}|#{twentyTimes}|\${twentyTimes}|\^{twentyTimes}");
            var tickets = Regex.Split(Console.ReadLine(), @"\s*,\s*");

            foreach (var ticket in tickets)
            {
                if (ticket.Length != 20)
                {
                    Console.WriteLine("invalid ticket");
                    continue;
                }

                var jackpotTicket = jackpotTicketPattern.Match(ticket);
                var left = winningTicketPattern.Match(ticket, 0, 10);
                var right = winningTicketPattern.Match(ticket, 10);

                if (jackpotTicket.Success)
                {
                    Console.WriteLine($"ticket \"{ticket}\" - 10{jackpotTicket.Value[0]} Jackpot!");
                }
                else if (left.Success && right.Success)
                {
                    var winner = left.Length < right.Length ? left : right;
                    int length = Math.Min(winner.Groups[1].Length, winner.Groups[1].Length);
                    Console.WriteLine($"ticket \"{ticket}\" - {length}{winner.Groups[1].Value[0]}");
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
