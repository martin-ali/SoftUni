using System;
using System.Collections.Generic;
using System.Linq;

namespace _05_hands_of_cards
{
    class HandsOfCards
    {
        private static Dictionary<string, int> cardPowersBySuite = new Dictionary<string, int>
        {
            ["2"] = 2,
            ["3"] = 3,
            ["4"] = 4,
            ["5"] = 5,
            ["6"] = 6,
            ["7"] = 7,
            ["8"] = 8,
            ["9"] = 9,
            ["10"] = 10,
            ["J"] = 11,
            ["Q"] = 12,
            ["K"] = 13,
            ["A"] = 14
        };

        private static Dictionary<char, int> cardTypesByFace = new Dictionary<char, int>
        {
            ['S'] = 4,
            ['H'] = 3,
            ['D'] = 2,
            ['C'] = 1
        };

        static void Main()
        {
            var playersAndTheirHands = new Dictionary<string, HashSet<string>>();

            var parameters = Console.ReadLine().Split(new string[] { ", ", ": " }, StringSplitOptions.RemoveEmptyEntries);
            while (parameters[0] != "JOKER")
            {
                var name = parameters[0];
                var cards = parameters.Skip(1);
                var hand = new HashSet<string>(cards);

                if (playersAndTheirHands.ContainsKey(name) == false)
                {
                    playersAndTheirHands[name] = new HashSet<string>();
                }

                playersAndTheirHands[name].UnionWith(hand);

                parameters = Console.ReadLine().Split(new string[] { ", ", ": " }, StringSplitOptions.RemoveEmptyEntries);
            }

            foreach (var player in playersAndTheirHands)
            {
                Console.WriteLine($"{player.Key}: {player.Value.Select(CardPower).Sum()}");
            }
        }

        private static int CardPower(string card)
        {
            string suite = card.Substring(0, card.Length - 1);
            char face = card.Last();

            var power = cardPowersBySuite[suite] * cardTypesByFace[face];
            return power;
        }
    }
}
/*

Pesho: 2C, 4H, 9H, AS, QS
Slav: 3H, 10S, JC, KD, 5S, 10S
Peshoslav: QH, QC, QS, QD
Slav: 6H, 7S, KC, KD, 5S, 10C
Peshoslav: QH, QC, JS, JD, JC
Pesho: JD, JD, JD, JD, JD, JD
JOKER

 */
