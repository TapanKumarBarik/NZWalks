using NZWalk.API.Models.Domain;

namespace NZWalk.API.Repository
{
    public class StaticUserRepository : IUserRepository
    {
        private List<User> Users = new List<User>()
        {
            new User()
                {
                    FirstName="Read Only",
                    LastName="User",
                    EmailAddress="readonly@user.com",
                    Id=Guid.NewGuid(),
                    UserName="readonly@user.com",
                    Password="Readonly@user",
                    //Roles=new List<string> { "reader"}
            },
             new User()
                {
                    FirstName="Read Write",
                    LastName="User",
                    EmailAddress="readwrite@user.com",
                    Id=Guid.NewGuid(),
                    UserName="readwrite@user.com",
                    Password="ReadWrite@user",
                   // Roles=new List<string> { "reader","writer"}
            }
        };
        public StaticUserRepository()
        {

        }
        public async Task<User> AuthenticateAsync(string userName, string password)
        {
            var user=Users.Find(x => 
            x.UserName.Equals(userName, StringComparison.InvariantCultureIgnoreCase)
            &&
            x.Password == password
            );

            
            return user;
        }
    }
}
