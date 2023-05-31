using LibraryApi.Models;
using Microsoft.EntityFrameworkCore;

namespace LibraryApi
{
    public class DatabaseContext : DbContext
    {
        public DbSet<Book> book { get; set; } = null!;
        public DbSet<User> User { get; set; }
        public DbSet<UserBook> userbook { get; set; }


        public DatabaseContext(DbContextOptions<DatabaseContext> options ) : base(options)
        {
            
        }
    }
}
