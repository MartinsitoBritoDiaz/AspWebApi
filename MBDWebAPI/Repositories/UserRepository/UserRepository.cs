using Azure.Core;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Web_API.Data.Context;
using Web_API.Modals;
using Web_API.Repositories.PatternRepository;

namespace Web_API.Repositories.UserRepository
{
    public class UserRepository : IUserRepository
    {

        private readonly Context _context;
        private Repository<User> _repository;

        public UserRepository(Context context)
        {
            _context = context;
            _repository = new Repository<User>(context);
        }
        public async Task<bool> CreateUser(User user)
        {
            try
            {
               return await _repository.Create(user);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<List<User>> GetUsers()
        {
            try
            {
                return await _repository.GetAll();
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
                return await _repository.GetById(id);
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
                return await _repository.Update(user, user.Id);
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
                return await _repository.Delete(id);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
