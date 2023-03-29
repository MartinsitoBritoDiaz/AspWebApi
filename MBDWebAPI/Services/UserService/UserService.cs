using Microsoft.AspNetCore.Http;
using System.Security.Claims;

namespace MBDWebAPI.Services.UserService
{
    public class UserService : IUserService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        public UserService(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }
        public string GetUserName()
        {
            var result = string.Empty;

            if(_httpContextAccessor.HttpContext is not null)
            {
                result = _httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.Name);
            }
                return result;
        }
    }
}
