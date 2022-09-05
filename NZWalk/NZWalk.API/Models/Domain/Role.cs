namespace NZWalk.API.Models.Domain
{
    public class Role
    {
        public Guid Id { get; set; }
        public string Code { get; set; }

        public List<User_Role> UserRoles { get; set; }
    }
}
