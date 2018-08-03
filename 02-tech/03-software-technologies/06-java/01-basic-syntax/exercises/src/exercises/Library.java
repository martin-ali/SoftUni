package exercises;

import java.util.ArrayList;

public class Library
{
    private String Name;
    private ArrayList<Book> books = new ArrayList<>();

    public Library(String name)
    {
        Name = name;
    }

    public void addBook(Book book)
    {
        this.books.add(book);
    }

    public String getName()
    {
        return Name;
    }

    public void setName(String name)
    {
        Name = name;
    }

    public ArrayList<Book> getBooks()
    {
        return books;
    }

    public void setBooks(ArrayList<Book> books)
    {
        this.books = books;
    }
}
