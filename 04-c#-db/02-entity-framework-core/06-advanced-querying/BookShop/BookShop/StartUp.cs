namespace BookShop
{
    using System;
    using System.Globalization;
    using System.Linq;
    using System.Text;
    using BookShop.Models.Enums;
    using Data;
    using Initializer;

    public class StartUp
    {
        public static void Main()
        {
            using (var db = new BookShopContext())
            {
                DbInitializer.ResetDatabase(db);
                var result = GetMostRecentBooks(db);

                Console.WriteLine(result);
            }
        }

        public static string GetBooksByAgeRestriction(BookShopContext context, string command)
        {
            var ageRestriction = (AgeRestriction)Enum.Parse(typeof(AgeRestriction), command, true);
            var result = new StringBuilder();

            context.Books
            .Where(b => b.AgeRestriction == ageRestriction)
            .OrderBy(b => b.Title)
            .Select(b => b.Title)
            .ToList()
            .ForEach(b => result.AppendLine(b));

            return result.ToString();
        }

        public static string GetGoldenBooks(BookShopContext context)
        {
            var result = new StringBuilder();

            context.Books
            .Where(b => b.EditionType == EditionType.Gold)
            .Where(b => b.Copies < 5000)
            .OrderBy(b => b.BookId)
            .Select(b => b.Title)
            .ToList()
            .ForEach(b => result.AppendLine(b));

            return result.ToString();
        }

        public static string GetBooksByPrice(BookShopContext context)
        {
            var result = new StringBuilder();

            context.Books
            .Where(b => b.Price > 40)
            .OrderByDescending(b => b.Price)
            .Select(b => new { b.Title, b.Price })
            .ToList()
            .ForEach(b => result.AppendLine($"{b.Title} - ${b.Price:0.00}"));

            return result.ToString();
        }

        public static string GetBooksNotReleasedIn(BookShopContext context, int year)
        {
            var result = new StringBuilder();

            context.Books
            .Where(b => b.ReleaseDate.Value.Year != year)
            .OrderBy(b => b.BookId)
            .Select(b => b.Title)
            .ToList()
            .ForEach(b => result.AppendLine(b));

            return result.ToString();
        }

        public static string GetBooksByCategory(BookShopContext context, string input)
        {
            var categories = input
                                .ToLower()
                                .Split(' ', StringSplitOptions.RemoveEmptyEntries);
            var result = new StringBuilder();

            context.Books
            .Where(b => b.BookCategories.Any(c => categories.Contains(c.Category.Name.ToLower())))
            .OrderBy(b => b.Title)
            .Select(b => b.Title)
            .ToList()
            .ForEach(b => result.AppendLine(b));

            return result.ToString();
        }

        public static string GetBooksReleasedBefore(BookShopContext context, string date)
        {
            var dateFilter = DateTime.ParseExact(date, "dd-MM-yyyy", CultureInfo.InvariantCulture);
            var result = new StringBuilder();

            context.Books
            .Where(b => b.ReleaseDate < dateFilter)
            .OrderByDescending(b => b.ReleaseDate)
            .Select(b => new { b.Title, b.EditionType, b.Price })
            .ToList()
            .ForEach(b => result.AppendLine($"{b.Title} - {b.EditionType} - ${b.Price:0.00}"));

            return result.ToString();
        }

        public static string GetAuthorNamesEndingIn(BookShopContext context, string input)
        {
            var result = new StringBuilder();

            context.Authors
            .Where(a => a.FirstName.EndsWith(input))
            .Select(a => $"{a.FirstName} {a.LastName}")
            .OrderBy(a => a)
            .ToList()
            .ForEach(a => result.AppendLine(a));

            return result.ToString();
        }

        public static string GetBookTitlesContaining(BookShopContext context, string input)
        {
            var pattern = input.ToLower();
            var result = new StringBuilder();

            context.Books
            .Where(b => b.Title.ToLower().Contains(pattern))
            .OrderBy(b => b.Title)
            .Select(b => b.Title)
            .ToList()
            .ForEach(b => result.AppendLine(b));

            return result.ToString();
        }

        public static string GetBooksByAuthor(BookShopContext context, string input)
        {
            var pattern = input.ToLower();
            var result = new StringBuilder();

            context.Books
            .Where(b => b.Author.LastName.ToLower().StartsWith(pattern))
            .OrderBy(b => b.BookId)
            .Select(b => new
            {
                Title = b.Title,
                Author = $"{b.Author.FirstName} {b.Author.LastName}"
            })
            .ToList()
            .ForEach(b => result.AppendLine($"{b.Title} ({b.Author})"));

            return result.ToString();
        }

        public static int CountBooks(BookShopContext context, int lengthCheck)
        {
            var result = context.Books
                            .Where(b => b.Title.Length > lengthCheck)
                            .Count();

            return result;
        }

        public static string CountCopiesByAuthor(BookShopContext context)
        {
            var result = new StringBuilder();

            context.Authors
            .OrderByDescending(a => a.Books.Sum(b => b.Copies))
            .Select(a => new
            {
                Author = $"{a.FirstName} {a.LastName}",
                Copies = a.Books.Sum(b => b.Copies)
            })
            .ToList()
            .ForEach(ac => result.AppendLine($"{ac.Author} - {ac.Copies}"));

            return result.ToString();
        }

        // FIXME: Makes many queries
        public static string GetTotalProfitByCategory(BookShopContext context)
        {
            var result = new StringBuilder();

            context.Categories
            .OrderByDescending(c => c.CategoryBooks.Sum(bc => bc.Book.Price * bc.Book.Copies))
            .ThenBy(c => c.Name)
            .Select(c => new
            {
                Category = c.Name,
                Profit = c.CategoryBooks.Sum(bc => bc.Book.Price * bc.Book.Copies)
            })
            .ToList()
            .ForEach(c => result.AppendLine($"{c.Category} ${c.Profit}"));

            return result.ToString();
        }

        // FIXME: Makes many queries
        public static string GetMostRecentBooks(BookShopContext context)
        {
            var result = new StringBuilder();

            var categories = context.Categories
                                .OrderBy(c => c.Name)
                                .Select(c => new
                                {
                                    Category = c.Name,
                                    Books = c.CategoryBooks
                                            .OrderByDescending(b => b.Book.ReleaseDate)
                                            .Take(3)
                                            .Select(b => new
                                            {
                                                Title = b.Book.Title,
                                                Year = b.Book.ReleaseDate.Value.Year
                                            })
                                            .ToList()
                                })
                                .ToList();

            foreach (var category in categories)
            {
                result.AppendLine($"--{category.Category}");

                foreach (var book in category.Books)
                {
                    result.AppendLine($"{book.Title} ({book.Year})");
                }
            }

            return result.ToString();
        }

        public static void IncreasePrices(BookShopContext context)
        {
            var books = context.Books
                        .Where(b => b.ReleaseDate.Value.Year < 2010)
                        .ToList();

            foreach (var book in books)
            {
                book.Price += 5;
            }

            context.SaveChanges();
        }

        public static int RemoveBooks(BookShopContext context)
        {
            var books = context.Books
                        .Where(b => b.Copies < 4200)
                        .ToList();

            var bookCategories = books.SelectMany(b => b.BookCategories).ToList();

            context.RemoveRange(bookCategories);

            context.RemoveRange(books);

            context.SaveChanges();

            return books.Count();
        }
    }
}
