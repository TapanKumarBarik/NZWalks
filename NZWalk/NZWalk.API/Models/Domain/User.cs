using System.ComponentModel.DataAnnotations.Schema;

namespace NZWalk.API.Models.Domain
{
    public class User
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public string EmailAddress { get; set; }
        public string Password { get; set; }
        //Navigation
        [NotMapped]
        public List<string> Roles { get; set; }
        public List<User_Role> UserRoles { get; set; }
    }
}
