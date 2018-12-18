using System.Linq;
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
            public string State { get; }

            public Request(string state)
            {
                State = state;
            }
        }

        public class Handler : IRequestHandler<Request, Result>
        {
            public Handler(ECommerceContext db)
            {
                _db = db;
            }

            public async Task<Result> Handle(Request request, CancellationToken cancellationToken)
            {
                var shippingDistanceDTO = _db.ShippingDistances.First(c => c.State == request.State);
                var distance = shippingDistanceDTO.Distance;

                var result = new Result
                {
                    cost = (int)(distance * 0.1)
                };

                return result;
            }

            private readonly ECommerceContext _db;

        }

        public class Result
        {
            public int cost { get; set; }
        }
    }
}
