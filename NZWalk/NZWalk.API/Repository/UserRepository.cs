using Microsoft.EntityFrameworkCore;
using NZWalk.API.Data;
using NZWalk.API.Models.Domain;

namespace NZWalk.API.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly NZWalksDbContext nZWalksDbContext;
        public UserRepository(NZWalksDbContext nZWalksDbContext)
        {
            this.nZWalksDbContext = nZWalksDbContext;

        }
        public async Task<User> AuthenticateAsync(string userName, string password)
        {
            var user=await nZWalksDbContext.User.FirstOrDefaultAsync(
                x=>x.UserName.ToLower() == userName.ToLower() 
                &&
                x.Password == password
                );

            if (user==null)
            {
                return null;
            }
            var userRoles= await nZWalksDbContext.User_Role.Where(
                x=>x.UserId==user.Id
                ).ToListAsync();

            if (userRoles.Any())
            {
                user.Roles = new List<string>();
                foreach (var userRol in userRoles)
                {
                    var role = await nZWalksDbContext.Role.FirstOrDefaultAsync(
                        x => x.Id == userRol.RoleId
                        );
                    if (role!=null)
                    {
                        user.Roles.Add(role.Code);
                    }
                }
            }
            user.Password = null;

            return user;
        }
    }
}
