using ECommerceData.User;

namespace ECommerceApplication.AuthService
{
    public class AuthService
    {
        public AuthService(UserRepository userRepo)
        {
            _userRepo = userRepo;
        }

        public void Register(string username, string password, string firstName, string lastName, string email)
        {
            _userRepo.CreateUser(username, password, firstName, lastName, email);
        }

        public bool CanLogin(string username, string password)
        {
            var canLogin = _userRepo.CheckIfUserExists(username, password);
            
            return canLogin;
        }

        public void Login(string username, string password)
        {

        }


        public User GetUser(string username, string password)
        {
            var user = _userRepo.GetUser(username, password);

            return user;
        }

        private readonly UserRepository _userRepo;
    }
}
