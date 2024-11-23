using LibraryApi.Data;
using LibraryApi.Models;
using Serilog;

namespace LibraryApi.Services;

public class BooksService : IBooksService
{
    private readonly LibraryContext _context;

    public BooksService(LibraryContext context)
    {
        _context = context;
    }

    public IEnumerable<Book> GetBooks() => _context.Books.ToList();

    public Book? GetBookById(int id) => _context.Books.FirstOrDefault(b => b.Id == id);

    public void AddBook(Book book)
    {
        _context.Books.Add(book);

        _context.SaveChanges();
        Log.Information($"Book {book.Title} added");
    }

    public void UpdateBook(int id, Book updatedBook)
    {
        var book = GetBookById(id);
        if (book != null)
        {
            book.Title = updatedBook.Title;
            book.Author = updatedBook.Author;
            book.Year = updatedBook.Year;
            
            _context.SaveChanges();
            Log.Information($"The Book {book.Title} is updated");   
        }
    }

    public void DeleteBook(int id)
    {
        var book = GetBookById(id);
        if(book != null) _context.Books.Remove(book);
    }
}