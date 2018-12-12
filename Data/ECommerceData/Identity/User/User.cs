namespace ECommerceData.Identity.User
{
    public class User
    {
        public string Username { get; }
        public string Password { get; }
        public string Email { get; }
        public string UserType { get; }

        public User(string username, string password, string email, string userType)
        {
            Username = username;
            Password = password;
            Email = email;
            UserType = userType;
        }
    }
}
