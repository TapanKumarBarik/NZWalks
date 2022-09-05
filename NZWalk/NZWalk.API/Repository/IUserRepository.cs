using NZWalk.API.Models.Domain;

namespace NZWalk.API.Repository
{
    public interface IUserRepository
    {
        Task<User> AuthenticateAsync(string userName, string password);
    }
}
