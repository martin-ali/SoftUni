package exercises;

import java.time.LocalDate;
import java.time.format.DateTimeFormatter;
import java.util.Comparator;
import java.util.Scanner;

public class x25BookLibraryModification
{
    public static void main(String[] args)
    {
        Scanner console = new Scanner(System.in);
        Library library = new Library("Unnecessary");

        int bookCount = Integer.parseInt(console.nextLine());
        for (int current = 0; current < bookCount; current++)
        {
            String[] bookData = console.nextLine().split(" ");

            String title = bookData[0];
            String author = bookData[1];
            String publisher = bookData[2];
            LocalDate releaseDate = LocalDate.parse(bookData[3], DateTimeFormatter.ofPattern("dd.MM.yyyy"));
            String isbn = bookData[4];
            double price = Double.parseDouble(bookData[5]);

            Book newBook = new Book(title, author, publisher, isbn, releaseDate, price);
            library.addBook(newBook);
        }

        LocalDate dateBorder = LocalDate.parse(console.nextLine(), DateTimeFormatter.ofPattern("dd.MM.yyyy"));

        library
                .getBooks()
                .stream()
                .filter(book -> book.getReleaseDate().isAfter(dateBorder))
                .sorted(Comparator
                        .comparing(Book::getReleaseDate)
                        .thenComparing(Book::getTitle))
                .forEach(book -> System.out.println(String.format("%s -> %s", book.getTitle(), book.getReleaseDate().format(DateTimeFormatter.ofPattern("dd.MM.yyyy")))));
    }
}

/*
5
LOTR Tolkien GeorgeAllen 29.07.1954 0395082999 30.00
Hobbit Tolkien GeorgeAll 21.09.1937 0395082888 10.25
HP1 JKRowling Bloomsbury 26.06.1997 0395082777 15.50
HP7 JKRowling Bloomsbury 21.07.2007 0395082666 20.00
AC OBowden PenguinBooks 20.11.2009 0395082555 14.00
30.07.1954
 */