using System.Linq;

namespace ECommerceData.User
{
    public class UserRepository
    {
        public UserRepository(ECommerceContext eCommerceContext)
        {
            _eCommerceContext = eCommerceContext;
        }

        public void CreateUser(string username, string password)
        {

            //if (_eCommerceContext.Users.Any(user))
            //    throw new UsernameAlreadyExistsException("msgasdgsdg");

            _eCommerceContext.Users.Add(new UserDTO
            {
                Username = username,
                Password = password
            });

        }

        public User GetUserByUsernameAndPassword(string username, string password)
        {
            var isFound = _eCommerceContext.Users.Any(user => user.Username == username && user.Password == password);

            if (!isFound)
            {
                return null;
            }

            var userDTO = _eCommerceContext.Users.First(user => user.Username == username && user.Password == password);

            var userToReturn = new User(userDTO.Username);

            return userToReturn;
        }

        private readonly ECommerceContext _eCommerceContext;
    }
}
