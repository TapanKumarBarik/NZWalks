using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NZWalk.API.Models.DTO;
using NZWalk.API.Repository;

namespace NZWalk.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IUserRepository userRepository;
        private readonly ITokenHandler tokenHandler;
        public AuthController(IUserRepository userRepository,ITokenHandler tokenHandler)
        {
            this.userRepository = userRepository;
            this.tokenHandler = tokenHandler;
        }

        [HttpPost]
        [Route("/login")]
        public async Task<IActionResult> LoginAsync(LoginRequest loginRequest)
        {
            if (loginRequest == null)
            {
                return BadRequest("User name and password should be present");
            }
            if (loginRequest.UserName == null)
            {
                return BadRequest("User name cannot be null");
            }
            if(loginRequest.Password == null)
            {
                return BadRequest("Password cannot be null");
            }
            //check if user is authenticated

            var user = await userRepository.AuthenticateAsync(loginRequest.UserName,loginRequest.Password);

            if (user!=null)
            {
                //generate token
                var token = await tokenHandler.CreateTokenHandlerAsync(user);
                return Ok(token);
            }
            return BadRequest("User name or password is incorrect");

        }
    }
}
