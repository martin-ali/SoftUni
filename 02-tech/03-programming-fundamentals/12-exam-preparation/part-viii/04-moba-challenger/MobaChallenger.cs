using System;
using System.Collections.Generic;
using System.Linq;

namespace _04_moba_challenger
{
    class MobaChallenger
    {
        static void Main()
        {
            var players = new Dictionary<string, Dictionary<string, int>>();
            var totalSkillByPlayer = new Dictionary<string, int>();

            var input = string.Empty;
            while ((input = Console.ReadLine()) != "Season end")
            {
                var info = input.Split(new[] { " vs ", " -> " }, StringSplitOptions.RemoveEmptyEntries);

                if (info.Length == 3) // Player -> Position -> Skill
                {
                    var player = info[0];
                    var position = info[1];
                    var skill = int.Parse(info[2]);

                    if (players.ContainsKey(player) == false)
                    {
                        players[player] = new Dictionary<string, int>();
                        totalSkillByPlayer[player] = 0;
                    }

                    if (players[player].ContainsKey(position) == false)
                    {
                        players[player][position] = skill;
                        totalSkillByPlayer[player] += skill;
                    }

                    if (skill > players[player][position])
                    {
                        totalSkillByPlayer[player] -= players[player][position];
                        players[player][position] = skill;
                        totalSkillByPlayer[player] += skill;
                    }
                }
                else // Player vs Player
                {
                    var firstPlayer = info[0];
                    var secondPlayer = info[1];
                    if (players.ContainsKey(firstPlayer) == false || players.ContainsKey(secondPlayer) == false)
                    {
                        continue;
                    }

                    var playersHaveCommonPosition = players[firstPlayer].Any(position => players[secondPlayer].ContainsKey(position.Key));
                    if (playersHaveCommonPosition == false)
                    {
                        continue;
                    }

                    if (totalSkillByPlayer[firstPlayer] > totalSkillByPlayer[secondPlayer])
                    {
                        players.Remove(secondPlayer);
                        totalSkillByPlayer.Remove(secondPlayer);
                    }
                    else if (totalSkillByPlayer[secondPlayer] > totalSkillByPlayer[firstPlayer])
                    {
                        players.Remove(firstPlayer);
                        totalSkillByPlayer.Remove(firstPlayer);
                    }
                }
            }

            var orderedPlayerPool = players
                                    .OrderByDescending(player => totalSkillByPlayer[player.Key])
                                    .ThenBy(player => player.Key);

            foreach (var player in orderedPlayerPool)
            {
                Console.WriteLine($"{player.Key}: {totalSkillByPlayer[player.Key]} skill");
                var orderedPositions = player
                                        .Value
                                        .OrderByDescending(position => position.Value)
                                        .ThenBy(position => position.Key);

                foreach (var position in orderedPositions)
                {
                    Console.WriteLine($"- {position.Key} <::> {position.Value}");
                }
            }
        }
    }
}
/*

Pesho -> Adc -> 400
Gosho -> Jungle -> 300
Stamat -> Mid -> 200
Stamat -> Support -> 250
Season end

Pesho -> Adc -> 400
Bush -> Tank -> 150
Faker -> Mid -> 200
Faker -> Support -> 250
Faker -> Tank -> 250
Pesho vs Faker
Faker vs Bush
Faker vs Hide
Season end

 */
