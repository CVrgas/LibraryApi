using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using LibraryApi.Models;

namespace LibraryApi.Entitites
{
    public class Students
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public ICollection<Book> Books { get; set; } = new List<Book>();
        public string Firstname { get; }

        public Students(string firstname, string lastname)
        {
            firstName = firstname;
            lastName = lastname;
        }
    }
}
