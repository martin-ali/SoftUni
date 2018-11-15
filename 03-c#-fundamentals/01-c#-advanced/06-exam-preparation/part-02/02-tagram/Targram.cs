using System;
using System.Collections.Generic;
using System.Linq;

namespace _02_tagram
{
    class Targram
    {
        static void Main()
        {
            var likesByTagByUser = new Dictionary<string, Dictionary<string, int>>();

            var input = Console.ReadLine();
            while (input != "end")
            {
                var data = input.Split(new[] { ' ', '-', '>' }, StringSplitOptions.RemoveEmptyEntries);

                if (data[0] == "ban")
                {
                    var username = data[1];
                    likesByTagByUser.Remove(username);
                }
                else
                {
                    var username = data[0];
                    var tag = data[1];
                    var likes = int.Parse(data[2]);

                    if (likesByTagByUser.ContainsKey(username) == false)
                    {
                        likesByTagByUser[username] = new Dictionary<string, int>();
                    }

                    if (likesByTagByUser[username].ContainsKey(tag) == false)
                    {
                        likesByTagByUser[username][tag] = 0;
                    }

                    likesByTagByUser[username][tag] += likes;
                }

                input = Console.ReadLine();
            }

            var sortedUsers = likesByTagByUser
                                .OrderByDescending(x => x.Value.Values.Sum())
                                .ThenBy(x => x.Value.Count);

            foreach (var user in sortedUsers)
            {
                Console.WriteLine(user.Key);

                foreach (var tag in user.Value)
                {
                    Console.WriteLine($"- {tag.Key}: {tag.Value}");
                }
            }
        }
    }
}
