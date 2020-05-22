namespace _04_telephony
{
    using System;
    using System.Linq;

    public class Smartphone : ICanCall, ICanBrowse
    {
        public string Browse(string url)
        {
            if (url.Any(char.IsDigit))
            {
                throw new ArgumentException("Invalid URL!");
            }

            return $"Browsing: {url}!";
        }

        public string Call(string number)
        {
            if (number.All(char.IsDigit) == false)
            {
                throw new ArgumentException("Invalid number!");
            }

            return $"Calling... {number}";
        }
    }
}