using System.Threading;
using System.Threading.Tasks;
using ECommerceData;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ECommerceApplication.Inventory.Queries
{
    public class InventoryItemQuery
    {
        public class Request : IRequest<Result>
        {
            public string SKU { get; set; }
        }

        public class Handler : IRequestHandler<Request, Result>
        {
            public Handler(ECommerceContext db)
            {
                _db = db;
            }

            public async Task<Result> Handle(Request request, CancellationToken cancellationToken)
            {
                var itemDTO = _db.InventoryItems.Include(ii => ii.Product).FirstAsync(ii => ii.Product.SKU == request.SKU).Result;

                return new Result(itemDTO.Product.SKU, itemDTO.Description, itemDTO.Category, itemDTO.UnitCost);
            }

            private readonly ECommerceContext _db;
        }

        public class Result
        {
            public string SKU { get; }
            public string Description { get; }
            public string Category { get; }
            public decimal UnitCost { get; }

            public Result(string sku, string description, string category, decimal unitCost)
            {
                SKU = sku;
                Description = description;
                Category = category;
                UnitCost = unitCost;
            }
        }
    }
}
