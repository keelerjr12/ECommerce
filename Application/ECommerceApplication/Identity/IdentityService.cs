using ECommerceData.Identity.User;

namespace ECommerceApplication.Identity
{
    public class IdentityService
    {
        public IdentityService(UserRepository userRepo)
        {
            _userRepo = userRepo;
        }

        public void Register(string username, string password, string firstName, string lastName, string email, string userType)
        {
            _userRepo.CreateUser(username, password, firstName, lastName, email, userType);
        }

        private readonly UserRepository _userRepo;
    }
}
