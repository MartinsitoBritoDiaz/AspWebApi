using MBDWebAPI.Modals;
using MBDWebAPI.Services.UserService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace MBDWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        public static User user = new User();
        public readonly IConfiguration _configuration;
        public readonly IUserService _userService;
        public AuthController(IConfiguration configuration, IUserService userService)
        {
            _configuration = configuration;
            _userService = userService;
        }

        [HttpGet, Authorize]
        public ActionResult<string> GetUserName()
        {
            return Ok( _userService.GetUserName() );
        }

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

            var token = CreateToken(user);

            return Ok(token);
        }

        private string CreateToken(User user)
        {
            //Create the claims with the roles
            List<Claim> claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, user.UserName),
                new Claim(ClaimTypes.Role, "Admin"),
                new Claim(ClaimTypes.Role, "User"),
            };

            //Encode the information with the secret string
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(
                _configuration.GetSection("AppSettings:Token").Value!));

            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

            //Set the claims, expire date and the cre dentials to the token
            var token = new JwtSecurityToken(
                claims: claims,
                expires: DateTime.Now.AddDays(1),
                signingCredentials: credentials
                );

            var jwt = new JwtSecurityTokenHandler().WriteToken(token);

            return jwt;
        }
    }
}
