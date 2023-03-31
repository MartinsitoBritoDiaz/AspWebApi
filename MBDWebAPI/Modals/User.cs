namespace Web_API.Modals
{
    public class User
    {
        public int Id { get; set; }
        public string UserName { get; set; } = string.Empty;
        public string Roles { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;

        public static User operator +(User user, UserRequestDTO userRequest)
        {
            user.UserName = userRequest.UserName;
            user.Password = userRequest.Password;
            user.Roles = "User";
            return user;
        }
    }
}
