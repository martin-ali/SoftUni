using System;
using System.Collections.Generic;
using System.Linq;

namespace _08_hands_of_cards
{
    class HandsOfCards
    {
        static void Main()
        {
            var DeckByPerson = new Dictionary<string, HashSet<string>>();
            var handout = Console.ReadLine();
            while (handout != "JOKER")
            {
                var handData = handout.Split(new string[] { ": ", ", " }, StringSplitOptions.RemoveEmptyEntries);

                var person = handData[0];
                var hand = handData.Skip(1);

                if (DeckByPerson.ContainsKey(person) == false)
                {
                    DeckByPerson[person] = new HashSet<string>();
                }

                DeckByPerson[person].UnionWith(hand);

                handout = Console.ReadLine();
            }

            foreach (var personAndDeck in DeckByPerson)
            {
                var score = personAndDeck.Value.Sum(c => GetCardPower(c));
                Console.WriteLine($"{personAndDeck.Key}: {score}");
            }
        }

        private static int GetCardPower(string card)
        {
            card = card.Replace("10", "X");

            var cardFace = 0;
            switch (card[0])
            {
                case 'X': cardFace = 10; break;
                case 'J': cardFace = 11; break;
                case 'Q': cardFace = 12; break;
                case 'K': cardFace = 13; break;
                case 'A': cardFace = 14; break;
                default: cardFace = int.Parse(card[0].ToString()); break;
            }

            var cardType = 0;
            switch (card[1])
            {
                case 'S': cardType = 4; break;
                case 'H': cardType = 3; break;
                case 'D': cardType = 2; break;
                case 'C': cardType = 1; break;
            }

            var cardPower = cardFace * cardType;
            return cardPower;
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
