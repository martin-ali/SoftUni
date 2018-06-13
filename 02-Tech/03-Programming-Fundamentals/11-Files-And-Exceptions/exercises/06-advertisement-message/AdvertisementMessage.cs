﻿using System;
using System.IO;

namespace _06_advertisement_message
{
    class AdvertisementMessage
    {
        static void Main()
        {
            var phrases = new[] { "Excellent product.", "Such a great product.", "I always use that product.", "Best product of its category.", "Exceptional product.", "I can’t live without this product." };
            var events = new[] { "Now I feel good.", "I have succeeded with this product.", "Makes miracles. I am happy of the results!", "I cannot believe but now I feel awesome.", "Try it yourself, I am very satisfied.", "I feel great!" };
            var authors = new[] { "Diana", "Petya", "Stella", "Elena", "Katya", "Iva", "Annie", "Eva" };
            var cities = new[] { "Burgas", "Sofia", "Plovdiv", "Varna", "Ruse" };

            var random = new Random();
            var phrase = random.Next(0, phrases.Length);
            var @event = random.Next(0, events.Length);
            var author = random.Next(0, authors.Length);
            var city = random.Next(0, cities.Length);

            var advertisement = $"{phrases[phrase]} {events[@event]} {authors[author]} - {cities[city]}";
            File.AppendAllText("output.txt", advertisement + Environment.NewLine);
        }
    }
}