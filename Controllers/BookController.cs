using LibraryApi.Models;
using LibraryApi.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LibraryApi.Controllers
{
    [Route("api/book")]
    [ApiController]
    public class BookController : ControllerBase
    {

        public IBookRepository _repository;

        public BookController(IBookRepository repository)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Book>>> GetAllBooks(string? arg)
        {
            var x = await _repository.getBooksAsync(arg);
            var result = new List<Book>();
            foreach (var book in x)
            {
                result.Add(book);
            }
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetBook(int id)
        {
            var book = await _repository.getBookByIdAsync(id);
            if (book == null)
            {
                return NotFound();
            }
            return Ok(book);
        }

        [HttpPost("post")]
        public async Task<ActionResult> Createbook(Book book)
        {
            if (book == null) { return NotFound(); }
            _repository.AddBookAsync(book);
            await _repository.SaveChangesAsync();
            return NoContent();
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Updatebook(Book book)
        {
            if(book == null) { return NotFound();}
            await _repository.UpdateBookAsync(book);
            await _repository.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete]
        public async Task<ActionResult> DeleteBook(Book book)
        {
            if(!await _repository.BookExistAsync(book.Id))
            {
                return NotFound();
            }
            _repository.DeleteBookAsync(book);
            await _repository.SaveChangesAsync(); 
            return NoContent();

        }
    }
}
