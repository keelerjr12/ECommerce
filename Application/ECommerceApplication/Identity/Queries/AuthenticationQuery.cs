using System;
using System.Threading;
using System.Threading.Tasks;
using ECommerceData;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ECommerceApplication.Identity.Queries
{
    public class AuthenticationQuery
    {
        public class Request : IRequest<Result>
        {
            public string Username { get; set; }
            public string Password { get; set; }
        }

        public class Handler : IRequestHandler<Request, Result>
        {
            public Handler(ECommerceContext db)
            {
                _db = db;
            }

            public async Task<Result> Handle(Request request, CancellationToken cancellationToken)
            {
                if (!await _db.Users.AnyAsync(u => u.Username == request.Username && u.Password == request.Password))
                {
                    return null;
                }

                var userDTO = _db.Users.FirstAsync(u => u.Username == request.Username && u.Password == request.Password).Result;

                var result = new Result
                {
                    Id = userDTO.Id,
                    Username = userDTO.Username,
                    Email = userDTO.Email,
                    UserType = userDTO.UserType
                };

                return result;
            }

            private readonly ECommerceContext _db;
        }

        public class Result
        {
            public Guid Id { get; set; }
            public string Username { get; set; }
            public string Email { get; set; }
            public string UserType { get; set; }
        }
    }
}
