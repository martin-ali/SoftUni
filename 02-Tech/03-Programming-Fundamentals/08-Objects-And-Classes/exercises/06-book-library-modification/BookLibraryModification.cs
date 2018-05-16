using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;

namespace _06_book_library_modification
{
    class BookLibraryModification
    {
        static void Main()
        {
            #if DEBUG
            Console.SetIn(new StreamReader("test.txt"));
            #endif

            var library = new Library("Useless", new List<Book>());
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
            var sortDate = DateTime.ParseExact(Console.ReadLine(), "dd.MM.yyyy", CultureInfo.InvariantCulture);

            var orderedBooks = library.Books
                            .Where(book => book.ReleaseDate > sortDate)
                            .OrderBy(book => book.ReleaseDate)
                            .ThenBy(Book => Book.Title);
            foreach (var book in orderedBooks)
            {
                Console.WriteLine($"{book.Title} -> {book.ReleaseDate:dd.MM.yyyy}");
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
