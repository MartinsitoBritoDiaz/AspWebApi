using Web_API.Modals;

namespace Web_API.Services.UserService
{
    public interface IUserService
    {
        string GetUserName();
        Task<List<User>> GetUsers();
        Task<User> GetUserById(int id);
        Task<bool> CreateUser(User user);
        Task<User> UpdateUser(User user);
        Task<bool> DeleteUserById(int id);
        Task<string> Login(UserDTO user);
    }
}
