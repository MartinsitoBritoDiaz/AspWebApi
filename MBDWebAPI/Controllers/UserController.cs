using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using Web_API.Modals;
using Web_API.Services.UserService;

namespace Web_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        public readonly IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }


        [SwaggerOperation(Summary = "Create a new user")]
        [HttpPost]
        public async Task<ActionResult<User>> Register(UserRequestDTO request)
        {

            var result = await _userService.CreateUser(request);

            if (result)
                return Ok();
            else
                return BadRequest();
        }

        [HttpGet]
        public async Task<ActionResult<List<User>>> GetAll()
        {

            var result = await _userService.GetUsers();

            if (result != null)
                return Ok( result );
            else
                return BadRequest();
        }
    }
}
