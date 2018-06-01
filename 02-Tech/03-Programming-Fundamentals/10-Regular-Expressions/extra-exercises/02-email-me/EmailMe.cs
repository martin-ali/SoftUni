using System;
using System.Linq;

namespace _02_email_me
{
    class EmailMe
    {
        static void Main()
        {
            var email = Console.ReadLine();
            var emailParts = email.Split('@');
            var sumBeforeAt = emailParts[0]
                                .Select(c => (int)c)
                                .Aggregate((sum, c) => (sum + c));
            var sumAfterAt = emailParts[1]
                                .Select(c => (int)c)
                                .Aggregate((sum, c) => (sum + c));

            var result = sumBeforeAt - sumAfterAt;
            if (result >= 0)
            {
                Console.WriteLine("Call her!");
            }
            else
            {
                Console.WriteLine("She is not the one.");
            }
        }
    }
}
