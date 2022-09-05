using NZWalk.API.Models.Domain;

namespace NZWalk.API.Repository
{
    public interface ITokenHandler
    {
        Task<string> CreateTokenHandlerAsync(User user);
    }
}
