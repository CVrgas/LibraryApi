using LibraryApi.Models;

namespace LibraryApi.Services
{
    public interface IUserBookRepository
    {
        //CRUD  Create / Read /  Update / Delete

        //Create
        void CreateUserBook(UserBook request);

        //Read All users all relations
        Task<IEnumerable<UserBook>> GetUserBooksAsync();
        //Read user's all relation
        Task<IEnumerable<UserBook>> GetUserBooksAsync(int? UserId);

        //Read user's one relation
        Task<UserBook>GetOneUserBookAsync(int UserId, int relationId);

        //Update
        // No update

        //Delete One relation
        Task DeleteUserBookAsync(int userId, int relationId);

        // Utilities
        // check if relation exist and save changes on Db.
        Task<bool> RelationExist(int relationId);
        Task<bool> RelationExist(int? userId, int? bookId);
        Task<bool> SaveChangesAsync();

    }
}
