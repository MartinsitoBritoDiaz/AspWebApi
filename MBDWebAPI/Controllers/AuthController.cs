using MBDWebAPI.Modals;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MBDWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        public static User user = new User();

        [HttpPost("register")]
        public ActionResult<User> Register(UserRequestDTO request)
        {
            string passwordHash
                = BCrypt.Net.BCrypt.HashPassword(request.Password);

            user.UserName= request.UserName;
            user.Password = passwordHash;

            return Ok(user);    
        }

        [HttpPost("login")]
        public ActionResult<User> Login(UserRequestDTO request)
        {
            if(user.UserName!= request.UserName)
            {
                return BadRequest("User not found.");
            }

            if(!BCrypt.Net.BCrypt.Verify(request.Password, user.Password))
            {
                return BadRequest("Wrong passwrod");
            }

            return Ok(user);
        }
    }
}
