using LibraryApi.Models;


namespace LibraryApi
{
    public class TempDb
    {
        public List<User> Users { get; set; }
        public static TempDb Instance { get; } = new TempDb();
        public TempDb() 
        {
           Users = new List<User>()
           {
               new User() { 
                   Id = 1, 
                   FirstName = "crsitian",
                   LastName = "vargas",
                   Email = "vrgas@gmail.com",
                   Password = "123",
               },
               new User() {
                   Id = 2,
                   FirstName = "yeika",
                   LastName = "robles",
                   Email = "robles@gmail.com",
                   Password = "123",
               },
               new User() {
                   Id = 3,
                   FirstName = "candy",
                   LastName = "vargas",
                   Email = "robles@gmail.com",
                   Password = "123",
               },
           };
            
        }
    }
}
