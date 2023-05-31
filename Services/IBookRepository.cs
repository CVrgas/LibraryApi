using LibraryApi.Models;

namespace LibraryApi.Services
{
    public interface IBookRepository
    {
        Task<IEnumerable<Book>> getBooksAsync();
        Task<IEnumerable<Book>> getBooksAsync(string? arg);
        Task<Book?> getBookByIdAsync(int id);
        void AddBookAsync(Book book);
        Task<Book?> UpdateBookAsync(Book book);
        void DeleteBookAsync(Book book);
        Task<bool> SaveChangesAsync();
        Task<bool> BookExistAsync(int BookId);

    }
}
