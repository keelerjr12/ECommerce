using System.Linq;

namespace ECommerceData.User
{
    public class UserRepository
    {
        public UserRepository(ECommerceContext eCommerceContext)
        {
            _eCommerceContext = eCommerceContext;
        }

        public void CreateUser(string username, string password, string firstName, string lastName, string email)
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

            _eCommerceContext.Users.Add(new UserDTO(username, password, firstName, lastName, email));
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
