using System.Linq;

namespace ECommerceData.Identity.User
{
    public class UserRepository
    {
        public UserRepository(ECommerceContext eCommerceContext)
        {
            _eCommerceContext = eCommerceContext;
        }

        public void CreateUser(string username, string password, string firstName, string lastName, string email, string userType)
        {
            if (username == null
                || password == null 
                || firstName == null
                || lastName == null
                || email == null
                || _eCommerceContext.Users.Any(_userDTO => _userDTO.Username == username))
            {
                throw new UserInfoInvalidException("User info inputs invalid.");
            }

            var userDTO = new UserDTO
            {
                Username = username,
                Password = password,
                Email = email
            };

            _eCommerceContext.Users.Add(userDTO);
            _eCommerceContext.SaveChanges();

        }

        public bool CheckIfUserExists(string username, string password)
        {
            var isFound = _eCommerceContext.Users.Any(user => user.Username == username && user.Password == password);

            return isFound;
        }

        public User GetUser(string username, string password)
        {
            var userDTO = _eCommerceContext.Users.First(_userDTO => _userDTO.Username == username && _userDTO.Password == password);

            var user = new User(userDTO.Username);

            return user;
        }

        private readonly ECommerceContext _eCommerceContext;
    }
}
