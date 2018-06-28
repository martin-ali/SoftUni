using System;

namespace _05_foreign_languages
{
    class ForeignLanguages
    {
        static void Main()
        {
            var country = Console.ReadLine();
            var language = "unknown";
            switch (country)
            {
                case "USA":
                case "England":
                    language = "English";
                    break;
                case "Spain":
                case "Argentina":
                case "Mexico":
                    language = "Spanish";
                    break;
            }

            Console.WriteLine(language);
        }
    }
}
