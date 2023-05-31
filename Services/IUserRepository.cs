using LibraryApi.DTOs;
using LibraryApi.Models;

namespace LibraryApi.Services
{
    public interface IUserRepository
    {
        Task<IEnumerable<User>> GetUsersAsync();
        Task<User?> GetUserByIdAsync(int Id);
        void CreateUser(RegisterDTO request);
        Task UpdateUser(User user);
        Task DeleteUser(int id);
        Task<bool> SaveChangesAsync();
        Task<User?> GetUserByRequestAsync(LoginDTO request);
        Task<bool> UserExistAsync(LoginDTO request);
        Task<bool> UserExistAsync(int? id);
        Task<bool> EmailExistAsync(string email);

    }
}
