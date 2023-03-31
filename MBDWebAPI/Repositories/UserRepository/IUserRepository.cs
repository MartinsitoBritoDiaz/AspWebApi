using Web_API.Modals;

namespace Web_API.Repositories.UserRepository
{
    public interface IUserRepository
    {
        Task<List<User>> GetUsers();
        Task<User> GetUserById(int id);
        Task<bool> CreateUser(User student);
        Task<User> UpdateUser(User student);
        Task<bool> DeleteUserById(int id);
    }
}
