using Web_API.Modals;

namespace Web_API.Services.UserService
{
    public interface IUserService
    {
        string GetUserName();
        Task<List<User>> GetUsers();
        Task<UserRequestDTO> GetUserById(int id);
        Task<bool> CreateUser(UserRequestDTO user);
        Task<UserRequestDTO> UpdateUser(UserRequestDTO user);
        Task<bool> DeleteUserById(int id);
    }
}
