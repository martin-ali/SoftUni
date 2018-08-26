using System;
using System.Collections.Generic;

namespace _09_user_logs
{
    class UserLogs
    {
        static void Main()
        {
            var messageCountByIpByUser = new SortedDictionary<string, Dictionary<string, int>>();

            var input = Console.ReadLine();
            while (input != "end")
            {
                var inputData = input.Split(new string[] { " ", "IP=", "message=", "user=" }, StringSplitOptions.RemoveEmptyEntries);
                var ip = inputData[0];
                var message = inputData[1];
                var user = inputData[2];

                if (messageCountByIpByUser.ContainsKey(user) == false)
                {
                    messageCountByIpByUser[user] = new Dictionary<string, int>();
                }

                if (messageCountByIpByUser[user].ContainsKey(ip) == false)
                {
                    messageCountByIpByUser[user][ip] = 0;
                }

                messageCountByIpByUser[user][ip]++;

                input = Console.ReadLine();
            }

            foreach (var user in messageCountByIpByUser)
            {
                Console.WriteLine($"{user.Key}:");

                var userIps = user.Value;
                var messageIndex = 1;
                foreach (var messageCount in userIps)
                {
                    var punctuation = (messageIndex++) < userIps.Count ? ',' : '.';
                    Console.WriteLine($"{messageCount.Key} => {messageCount.Value}{punctuation}");
                }
            }
        }
    }
}
/*

IP=192.23.30.40 message='Hello&derps.' user=destroyer
IP=192.23.30.41 message='Hello&yall.' user=destroyer
IP=192.23.30.40 message='Hello&hi.' user=destroyer
IP=192.23.30.42 message='Hello&Dudes.' user=destroyer
end

IP=FE80:0000:0000:0000:0202:B3FF:FE1E:8329 message='Hey&son'user=mother
IP=192.23.33.40 message='Hi&mom!' user=child0
IP=192.23.30.40 message='Hi&from&me&too' user=child1
IP=192.23.30.42 message='spam' user=destroyer
IP=192.23.30.42 message='spam' user=destroyer
IP=192.23.50.40 message='' user=yetAnotherUsername
IP=192.23.50.40 message='comment' user=yetAnotherUsername
IP=192.23.155.40 message='Hello.' user=unknown
end

*/
