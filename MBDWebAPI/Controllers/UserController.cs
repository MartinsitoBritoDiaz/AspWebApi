using Microsoft.AspNetCore.Authorization;
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
        [HttpPost, Authorize]
        public async Task<ActionResult<User>> Create(User request)
        {

            var result = await _userService.CreateUser(request);

            if (result)
                return Ok();
            else
                return BadRequest();
        }

        [SwaggerOperation(Summary = "Get all users")]
        [HttpGet]
        public async Task<ActionResult<List<User>>> GetAll()
        {

            var result = await _userService.GetUsers();

            if (result != null)
                return Ok( result );
            else
                return BadRequest();
        }

        [SwaggerOperation(Summary = "Get user by id")]
        [HttpGet("{id}")]
        public async Task<ActionResult<User>> GetById(int id)
        {
            var result = await _userService.GetUserById(id);

            if (result != null)
                return Ok(result);
            else
                return BadRequest();
        }
        
        [SwaggerOperation(Summary = "Update a user ")]
        [HttpPut, Authorize]
        public async Task<ActionResult<User>> Update(User user)
        {
            try
            {
                var result = await _userService.UpdateUser(user);

                return Ok(result);
            }
            catch (Exception)
            {
                throw;
            }
        }

        [SwaggerOperation(Summary = "Delete a user")]
        [HttpDelete("{id}"), Authorize]
        public async Task<ActionResult<bool>> Delete(int id)
        {
            try
            {
                await _userService.DeleteUserById(id);

                return Ok();
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
