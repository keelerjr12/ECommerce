using System.Linq;
using ECommerceDomain.Identity.User;

namespace ECommerceData.Identity.User
{
    public class UserRepository : IUserRepository
    {
        public UserRepository(ECommerceContext eCommerceContext)
        {
            _eCommerceContext = eCommerceContext;
        }

        public void Save(ECommerceDomain.Identity.User.User user)
        {
            if (user.Username == null
                || user.Password == null
                || user.Email == null
                || user.UserType == null)
            {
                throw new UserInfoInvalidException("User info inputs invalid.");
            }

            if (DoesUserExist(user))
            {
                var userDTO = GetUserDTO(user);
                userDTO.Username = user.Username;
                userDTO.Password = user.Password;
                userDTO.Email = user.Email;
                userDTO.UserType = user.UserType;
            }
            else
            {
                var userDTO = new UserDTO
                {
                    Id = user.Id,
                    Username = user.Username,
                    Password = user.Password,
                    Email = user.Email,
                    UserType = user.UserType
                };

                _eCommerceContext.Users.Add(userDTO);
            }
        }

        private bool DoesUserExist(ECommerceDomain.Identity.User.User user)
        {
            var isFound = _eCommerceContext.Users.Any(userDTO => userDTO.Username == user.Username);

            return isFound;
        }

        private UserDTO GetUserDTO(ECommerceDomain.Identity.User.User user)
        {
            return _eCommerceContext.Users.First(userDTO => userDTO.Username == user.Username);
        }

        private readonly ECommerceContext _eCommerceContext;
    }
}
