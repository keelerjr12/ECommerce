using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using ECommerceData;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ECommerceApplication.Identity
{
    public class AuthenticationQueryHandler : IRequestHandler<AuthenticationQuery, AuthenticationQueryResult>
    {
        public AuthenticationQueryHandler(ECommerceContext db)
        {
            _db = db;
        }

        public async Task<AuthenticationQueryResult> Handle(AuthenticationQuery request, CancellationToken cancellationToken)
        {
            if (!await _db.Users.AnyAsync(u => u.Username == request.Username && u.Password == request.Password))
            {
                return null;
            }

            var userDTO = _db.Users.FirstAsync(u => u.Username == request.Username && u.Password == request.Password).Result;

            var result = new AuthenticationQueryResult
            {
                Id = userDTO.Id,
                Username = userDTO.Username,
                Email = userDTO.Email
            };

            return result;
        }

        private readonly ECommerceContext _db;
    }
}
