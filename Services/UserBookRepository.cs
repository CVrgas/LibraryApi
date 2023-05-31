using LibraryApi.Models;
using Microsoft.EntityFrameworkCore;

namespace LibraryApi.Services
{
    public class UserBookRepository : IUserBookRepository
    {
        private readonly DatabaseContext _context;

        public UserBookRepository(DatabaseContext context)
        {
            _context = context;
        }
        //Crete
        public void CreateUserBook(UserBook request)
        {
            _context.Add(request);
        }

        //Read
        // read all relation / read one user - all relation / read one user - one relation
        public async Task<IEnumerable<UserBook>> GetUserBooksAsync()
        {

            return await _context.userbook.ToListAsync();
        }

        public async Task<IEnumerable<UserBook>> GetUserBooksAsync(int? UserId)
        {

            return await _context.userbook.Where(r => r.UserId == UserId).ToListAsync();
        }
        public async Task<UserBook> GetOneUserBookAsync(int UserId, int relationId)
        {
            return await _context.userbook.Where(r => r.UserId == UserId && r.Id == relationId).FirstOrDefaultAsync();
        }

        //No update

        //Delete
        public async Task DeleteUserBookAsync(int userId, int relationId)
        {
            var relation = await GetOneUserBookAsync(userId, relationId);
            _context.userbook.Remove(relation);
        }


        //Utilities

        public async Task<bool> RelationExist(int relationId)
        {
            return await _context.userbook.AnyAsync(r => r.Id == relationId);
        }
        public async Task<bool> RelationExist(int? userId, int? bookId)
        {
            return await _context.userbook.AnyAsync(r => r.UserId == userId && r.BookId == bookId);
        }
        public async Task<bool> SaveChangesAsync()
        {
            return (await _context.SaveChangesAsync() >= 0);
        }

    }
}
