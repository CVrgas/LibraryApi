using LibraryApi.DTOs;
using LibraryApi.Models;
using Microsoft.EntityFrameworkCore;

namespace LibraryApi.Services
{
    public class UserRepository : IUserRepository
    {
        private readonly DatabaseContext _context;

        public UserRepository(DatabaseContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }


        // fix return type.

        public Task DeleteUser(int id)
        {
            throw new NotImplementedException();
        }
        public async Task<bool> UserExistAsync(int? id)
        {
            return await _context.User.AnyAsync(x => x.Id == id);
        }

        public async Task<User?> GetUserByIdAsync(int Id)
        {
            return await _context.User.Where(u => u.Id == Id).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<User>> GetUsersAsync()
        {
            return await _context.User.ToListAsync();
        }

        public async Task<bool> SaveChangesAsync()
        {
            return (await _context.SaveChangesAsync() >= 0);
        }

        public Task UpdateUser(User user)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> UserExistAsync(LoginDTO request)
        {
            return await _context.User.AnyAsync(u => u.Email == request.Email && u.Password == request.Password);            
        }
        public async Task<User?> GetUserByRequestAsync(LoginDTO request)
        {
            return await _context.User.Where(u => u.Email == request.Email && u.Password == request.Password).FirstOrDefaultAsync();
        }

        public void CreateUser(RegisterDTO request)
        {
            User newUser = new User()
            {
                FirstName = request.FirstName,
                LastName = request.LastName,
                Email = request.Email,
                Password = request.Password,
            };
            _context.User.Add(newUser);

        }

        public Task<bool> EmailExistAsync(string email)
        {
            return _context.User.AnyAsync(u => u.Email == email);
        }
    }
}
