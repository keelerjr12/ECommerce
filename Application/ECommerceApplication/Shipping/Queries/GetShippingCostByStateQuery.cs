using System.Threading;
using System.Threading.Tasks;
using ECommerceData;
using MediatR;

namespace ECommerceApplication.Shipping.Queries
{
    public class GetShippingCostByStateQuery
    {
        public class Request : IRequest<Result>
        {

        }

        public class Handler : IRequestHandler<Request, Result>
        {
            public Handler(ECommerceContext db)
            {
                _eCommerceContext = db;
            }

            public async Task<Result> Handle(Request request, CancellationToken cancellationToken)
            {
                throw new System.NotImplementedException();
            }

            private readonly ECommerceContext _eCommerceContext;
        }

        public class Result
        {

        }
    }
}
