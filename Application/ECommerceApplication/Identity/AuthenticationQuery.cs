using MediatR;

namespace ECommerceApplication.Identity
{
    public class AuthenticationQuery : IRequest<AuthenticationQueryResult>
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }
}
