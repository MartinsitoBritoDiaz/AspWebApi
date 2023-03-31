using Azure.Core;
using Microsoft.AspNetCore.Http;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using Web_API.Modals;
using Web_API.Repositories.UserRepository;
using Web_API.Services.UserService;

namespace MBDWebAPI.Services.UserService
{
    public class UserService : IUserService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        IUserRepository _userRepository;
        public UserService(IHttpContextAccessor httpContextAccessor, IUserRepository userRepository)
        {
            _httpContextAccessor = httpContextAccessor;
            _userRepository = userRepository;
        }

        public async Task<bool> CreateUser(UserRequestDTO user)
        {
            try
            {
                User userDB = new User();

                if ( !verifyFields(user) )
                    throw new Exception("User couldn't be saved");

                user.Password = BCrypt.Net.BCrypt.HashPassword(user.Password);

                var userToDb = userDB + user;

                return await _userRepository.CreateUser(userToDb);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public Task<bool> DeleteUserById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<UserRequestDTO> GetUserById(int id)
        {
            throw new NotImplementedException();
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

        public async Task<List<User>> GetUsers()
        {
            try
            {
                return await _userRepository.GetUsers();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public Task<UserRequestDTO> UpdateUser(UserRequestDTO user)
        {
            throw new NotImplementedException();
        }

        private bool verifyFields(UserRequestDTO user)
        {
            bool verified = true;

            if (user.UserName.IsNullOrEmpty())
            {
                verified = false;
                throw new Exception("Must provide a valid UserName");
            }

            if (user.Password.IsNullOrEmpty())
            {
                verified = false;
                throw new Exception("You must enter a valid password");
            }else if(user.Password.Length <= 0)
            {
                verified = false;
                throw new Exception("Password should have at least 6 characters");
            }


            return verified;
        }
    }
}
