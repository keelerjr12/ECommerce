using ECommerceData.User;

namespace ECommerceApplication.AuthService
{
    public class AuthService
    {
        public AuthService(UserRepository userRepo)
        {
            _userRepo = userRepo;
        }

        public void Register(string username, string password)
        {
            _userRepo.CreateUser(username, password);
        }

        public bool CanLogin(string username, string password)
        {
            var user = _userRepo.GetUserByUsernameAndPassword(username, password);

            return user != null;
        }

        private readonly UserRepository _userRepo;
    }
}
