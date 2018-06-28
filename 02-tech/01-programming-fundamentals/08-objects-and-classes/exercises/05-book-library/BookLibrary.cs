using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;

namespace _05_book_library
{
    class BookLibrary
    {
        static void Main()
        {
            #if DEBUG
            Console.SetIn(new StreamReader("test.txt"));
            #endif

            var library = new Library("Unnecessary", new List<Book>());
            var numberOfBooks = int.Parse(Console.ReadLine());
            for (int i = 0; i < numberOfBooks; i++)
            {
                var parameters = Console.ReadLine().Split(' ');
                var title = parameters[0];
                var author = parameters[1];
                var publisher = parameters[2];
                var releaseDate = DateTime.ParseExact(parameters[3], "dd.MM.yyyy", CultureInfo.InvariantCulture);
                var isbn = parameters[4];
                var price = decimal.Parse(parameters[5]);

                var book = new Book(title, author, publisher, releaseDate, isbn, price);
                library.Books.Add(book);
            }

            var orderedPrices = library.Books
                            .GroupBy(book => book.Author, book => book.Price)
                            .OrderByDescending(pricesByAuthor => pricesByAuthor.Sum())
                            .ThenBy(pricesByAuthor => pricesByAuthor.Key);
            foreach (var pricesByAuthor in orderedPrices)
            {
                Console.WriteLine($"{pricesByAuthor.Key} -> {pricesByAuthor.Sum():0.00}");
            }
        }
    }

    internal class Library
    {
        public Library(string name, List<Book> books)
        {
            this.Name = name;
            this.Books = books;
        }

        public string Name { get; set; }

        public List<Book> Books { get; set; }
    }

    internal class Book
    {
        public Book(string title, string author, string publisher, DateTime releaseDate, string isbn, decimal price)
        {
            this.Title = title;
            this.Author = author;
            this.Publisher = publisher;
            this.ReleaseDate = releaseDate;
            this.ISBN = isbn;
            this.Price = price;
        }

        public string Title { get; set; }

        public string Author { get; set; }

        public string Publisher { get; set; }

        public DateTime ReleaseDate { get; set; }

        public string ISBN { get; set; }

        public decimal Price { get; set; }
    }
}
