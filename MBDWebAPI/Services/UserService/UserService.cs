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

        public async Task<bool> CreateUser(User user)
        {
            try
            {
                User userDB = new User();

                if ( !verifyFields(user) )
                    throw new Exception("User couldn't be saved");

                user.Password = BCrypt.Net.BCrypt.HashPassword(user.Password);

                return await _userRepository.CreateUser(user);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<bool> DeleteUserById(int id)
        {
            try
            {
                return await _userRepository.DeleteUserById(id);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<User> GetUserById(int id)
        {
            try
            {
                return await _userRepository.GetUserById(id);
            }
            catch (Exception)
            {
                throw;
            }
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

        public async Task<string> Login(UserDTO user)
        {
            try
            {
                string result = "sd";

                return result;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<User> UpdateUser(User user)
        {
            try
            {
                User userDB = new User();

                if (!verifyFields(user))
                    throw new Exception("User couldn't be saved");

                user.Password = BCrypt.Net.BCrypt.HashPassword(user.Password);

                return await _userRepository.UpdateUser(user);
            }
            catch (Exception)
            {
                throw;
            }
        }

        private bool verifyFields(User user)
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
