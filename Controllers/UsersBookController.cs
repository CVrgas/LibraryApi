using LibraryApi.Models;
using LibraryApi.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LibraryApi.Controllers
{
    [Route("api/{userId}/book")]
    [ApiController]
    public class UsersBookController : ControllerBase
    {
        private readonly IUserBookRepository repository;
        private readonly IBookRepository books;
        private readonly IUserRepository users;

        public UsersBookController(IUserBookRepository repository, IBookRepository books, IUserRepository users)
        {
            this.repository = repository ?? throw new ArgumentNullException(nameof(repository));
            this.books = books ?? throw new ArgumentNullException(nameof(books));
            this.users = users ?? throw new ArgumentNullException(nameof(users));
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserBook>>> GetAllRelation([FromRoute] int userId)
        {
            return Ok(await repository.GetUserBooksAsync(userId));
        }
        
        [HttpGet("{relationId}")]
        public async Task<ActionResult<IEnumerable<UserBook>>> GetOneRelation(int userId, int relationId)
        {
            if(!await users.UserExistAsync(userId) || !await repository.RelationExist(relationId))
            {
                return NotFound();
            }
            return Ok(await repository.GetOneUserBookAsync(userId, relationId));

        }
        
        [HttpPut]
        public async Task<ActionResult> CreateRelation([FromRoute]int userId, int bookId)
        {
            if( !await books.BookExistAsync(bookId) || !await users.UserExistAsync(userId) )
            {
                return NotFound("book or user not found");
            }
            if( await repository.RelationExist(userId, bookId))
            {
                return Ok("Relation Already Exist");
            }
            var new_relation = new UserBook { UserId = userId,BookId = bookId };

            repository.CreateUserBook(new_relation);
            await repository.SaveChangesAsync();
            return Ok();
        }
        
        [HttpDelete]
        public async Task<ActionResult> DeleteRelation(int userId, int relationId)
        {
            await repository.DeleteUserBookAsync(userId, relationId);
            await repository.SaveChangesAsync();
            return Ok();
        }

    }
}
