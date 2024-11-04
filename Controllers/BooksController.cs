using LibraryApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace LibraryApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BooksController : ControllerBase
    {
        public static List<Book> books = new List<Book>
        {
            new Book { Id = 1, Title = "1984", Author = "Georg Orvell", Year = 1949 },
            new Book { Id = 2, Title = "To Kill", Author = "Harpe Lee", Year = 1960 }
        };

        // GET: api/books
        [HttpGet]
        public ActionResult<IEnumerable<Book>> GetBooks()
        {
            return Ok(books);
        }

        // GET: api/books/{id}
        [HttpGet("{id}")]
        public ActionResult<Book> GetBook(int id)
        {
            var book = books.FirstOrDefault(b => b.Id == id);
            if (book == null)
            {
                NotFound();
            }
            return Ok(book);
        }
        
        [HttpPost]
        public ActionResult<Book> CreateBook(Book newBook)
        {
            newBook.Id = books.Max(b => b.Id) + 1;
            books.Add(newBook);
            return CreatedAtAction(nameof(GetBook), new {id = newBook.Id}, newBook); 
        }

        // PUT: api/books/{id}

        [HttpPut("{id}")]
        public ActionResult UpdateBook(int id, Book updatedBook)
        {
            var existingBook = books.FirstOrDefault(b => b.Id == id);
            if(existingBook == null)
            {
                return NotFound();
            }
            existingBook.Title = updatedBook.Title;
            existingBook.Author = updatedBook.Author;
            existingBook.Year = updatedBook.Year;

            return NoContent();
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteBook(int id)
        {
            var book = books.FirstOrDefault(b => b.Id == id);
            if(book == null)
            {
                return NotFound();
            }

            books.Remove(book);
            return NoContent();
        }
    }
}