using ECommerceData;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using ECommerceData.Identity.User;
using ECommerceDomain.Identity.User;

namespace ECommerceApplication.Identity.Commands
{
    public class RegisterUserCommand
    {
        public class Request : IRequest
        {
            public string Username { get; }
            public string Password { get; }
            public string Email { get; }
            public string UserType { get; }

            public Request(string username, string password, string email, string userType)
            {
                Username = username;
                Password = password;
                Email = email;
                UserType = userType;
            }
        }

        public class Handler : IRequestHandler<Request>
        {
            public Handler(UnitOfWork uow, UserRepository userRepo)
            {
                _uow = uow;
                _userRepo = userRepo;
            }

            public Task<Unit> Handle(Request request, CancellationToken cancellationToken)
            {
                var user = new User(request.Username, request.Password, request.Email, request.UserType);
                _userRepo.Save(user);

                _uow.Save();

                return Unit.Task;
            }

            private readonly UnitOfWork _uow;
            private readonly UserRepository _userRepo;
        }
    }
}
