using LibraryApi.DTOs;
using LibraryApi.Models;
using LibraryApi.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LibraryApi.Controllers
{
    [Route("api/user")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository repository;

        public UserController(IUserRepository repository, TempDb temp)
        {
            this.repository = repository;
            Temp = temp ?? throw new ArgumentNullException(nameof(temp));
        }

        public TempDb Temp { get; }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<User>>> GetUsersAsync()
        {
            var users = await repository.GetUsersAsync();
            return Ok(users);
        }

        [HttpPost("login")]
        public async Task<ActionResult<LoginDTO>> LogInAsync(LoginDTO Request)
        {
            var y = await repository.UserExistAsync(Request);
            if (y)
            {
                var x = await repository.GetUserByRequestAsync(Request);
                return Ok(x);
            }
            return NoContent();
        }

        [HttpPut("signup")]
        public async Task<ActionResult> CreateUser(RegisterDTO Request)
        {
            if( await repository.EmailExistAsync(Request.Email))
            {
                return BadRequest();
            }
            repository.CreateUser(Request);
            await repository.SaveChangesAsync();

            return Ok();

        }
    }
}
