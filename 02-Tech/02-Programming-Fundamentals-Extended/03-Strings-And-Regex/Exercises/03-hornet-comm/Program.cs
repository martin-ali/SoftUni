using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace _03_hornet_comm
{
    // Best thing I ever found in StackOverflow!
    public static class Extensions
    {
        public static void Deconstruct<T>(this IList<T> list, out T first, out T second)
        {

            first = list.Count > 0 ? list[0] : default(T); // or throw
            second = list.Count > 1 ? list[1] : default(T);
        }

        public static void Deconstruct<T>(this IList<T> list, out T first, out T second, out IList<T> rest)
        {
            first = list.Count > 0 ? list[0] : default(T); // or throw
            second = list.Count > 1 ? list[1] : default(T); // or throw
            rest = list.Skip(2).ToList();
        }
    }

    class Program
    {
        private static string privateMessagePattern = @"^([\d]+) <-> ([a-zA-Z\d]+)$";

        private static string broadcastPattern = @"^([^\d]+) <-> ([a-zA-Z\d]+)$";

        static void Main()
        {
            var privateMessages = new List<(string code, string message)>();
            var broadcasts = new List<(string frequency, string message)>();

            var input = Console.ReadLine();
            while (input != "Hornet is Green")
            {
                if (Regex.IsMatch(input, privateMessagePattern))
                {
                    var (code, message) = input.Split(separator: new string[] { " <-> " }, options: StringSplitOptions.None);
                    var result = DecryptPrivateMessage(code, message);

                    privateMessages.Add(result);
                }
                else if (Regex.IsMatch(input, broadcastPattern))
                {
                    var (message, frequency) = input.Split(separator: new string[] { " <-> " }, options: StringSplitOptions.None);
                    var result = DecryptBroadcast(frequency, message);

                    broadcasts.Add(result);
                }

                input = Console.ReadLine();
            }

            Console.WriteLine("Broadcasts:");
            if (broadcasts.Count > 0)
            {
                broadcasts.ForEach(broadcast => Console.WriteLine($"{broadcast.frequency} -> {broadcast.message}"));
            }
            else
            {
                Console.WriteLine("None");
            }

            Console.WriteLine("Messages:");
            if (privateMessages.Count > 0)
            {
                privateMessages.ForEach(message => Console.WriteLine($"{message.code} -> {message.message}"));
            }
            else
            {
                Console.WriteLine("None");
            }
        }

        private static (string code, string message) DecryptPrivateMessage(string code, string message)
        {
            var reversedCode = String.Join(String.Empty, code.ToCharArray().Reverse());
            return (reversedCode, message);
        }

        private static (string frequency, string message) DecryptBroadcast(string frequency, string message)
        {
            var invertedCaseFrequency = string.Join("", frequency.Select(letter => letter == char.ToUpper(letter) ? char.ToLower(letter) : char.ToUpper(letter)));
            return (invertedCaseFrequency, message);
        }
    }
}
