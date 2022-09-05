using Microsoft.IdentityModel.Tokens;
using NZWalk.API.Models.Domain;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace NZWalk.API.Repository
{
    public class TokenHandler : ITokenHandler
    {
        private readonly IConfiguration configuration;
        public TokenHandler(IConfiguration configuration)
        {
            this.configuration = configuration;

        }
        public Task<string> CreateTokenHandlerAsync(User user)
        {
            //Create claims
            var clams = new List<Claim>();
            clams.Add(new Claim(ClaimTypes.GivenName, user.FirstName));
            clams.Add(new Claim(ClaimTypes.Surname, user.LastName));
            clams.Add(new Claim(ClaimTypes.Email, user.EmailAddress));

            //loop into roles of user

            user.Roles.ForEach((role) =>
            {
                clams.Add(new Claim(ClaimTypes.Role, role));
            });

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["jwt:key"]));

            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                configuration["jwt:Issuer"],
                configuration["jwt:Audience"],
                clams,
                expires:DateTime.Now.AddMinutes(15),
                signingCredentials:credentials

                );
            return Task.FromResult(new JwtSecurityTokenHandler().WriteToken(token));
        }
    }
}
