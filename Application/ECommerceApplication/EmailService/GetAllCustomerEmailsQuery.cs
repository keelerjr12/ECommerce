using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using ECommerceData;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ECommerceApplication.EmailService
{
    public class GetAllCustomerEmailsQuery
    {
        public class Request : IRequest<Result>
        {

        }

        public class Handler : IRequestHandler<Request, Result>
        {
            public Handler(ECommerceContext db)
            {
                _db = db;
            }

            public async Task<Result> Handle(Request request, CancellationToken cancellationToken)
            {
                var subscribedEmails = _db.Customers.Where(c => c.IsSubscribed).Include(c => c.User.Email).Select(c => c.User.Email).ToList();

                var result = new Result
                {
                    SubscribedEmails = subscribedEmails
                };

                return result;
            }

            private readonly ECommerceContext _db;

        }

        public class Result
        {
            public List<string> SubscribedEmails { get; set; }
        }
    }
}
