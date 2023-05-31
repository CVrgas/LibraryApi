using LibraryApi.Models;
using Microsoft.EntityFrameworkCore;

namespace LibraryApi.Services
{
    public class BookRepository : IBookRepository
    {
        private readonly DatabaseContext _context;

        public BookRepository(DatabaseContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }
        public Task<Book?> getBookByIdAsync(int id)
        {
            return _context.book.Where(b => b.Id == id).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Book>> getBooksAsync()
        {
            return await _context.book.ToListAsync();
        }
        public async Task<IEnumerable<Book>> getBooksAsync(string? arg)
        {
            if (string.IsNullOrEmpty(arg))
            {
                return await getBooksAsync();
            }
            arg = arg.Trim();

            return await _context.book
                .Where(
                    b => b.Title.Contains(arg) 
                    | b.Description.Contains(arg)
                    | b.Author.Contains(arg))
                .ToListAsync();
        }

        public void AddBookAsync(Book book)
        {
            if (book != null)
            {
                _context.book.Add(book);
            }
        }

        public async void DeleteBookAsync(Book book)
        {
            _context.book.Remove(book);
            await _context.SaveChangesAsync();
        }

        public Task<Book?> UpdateBookAsync(Book book)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> SaveChangesAsync()
        {
            return (await _context.SaveChangesAsync() >= 0);
        }
        public async Task<bool> BookExistAsync(int BookId)
        {
            if(await _context.book.AnyAsync(x => x.Id == BookId))
            {
                return true;
            }
            return false;
        }
    }
}


