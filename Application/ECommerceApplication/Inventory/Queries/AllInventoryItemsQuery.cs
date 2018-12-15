using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using ECommerceData;
using ECommerceData.Inventory.Inventory;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ECommerceApplication.Inventory.Queries
{
    public class AllInventoryItemsQuery
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
                var itemDTOs = _db.InventoryItems.Include(i => i.Product).Include(i => i.Entries).ToList();
                var totalStock = 0;
                var totalValue = 0m;

                var items = new List<InventoryItemDTO>();
                foreach (var item in itemDTOs)
                {
                    var stock = CalculateStock(item.Entries);
                    totalStock += stock;
                    totalValue += stock * item.UnitCost;

                    items.Add(new InventoryItemDTO(item.Product.SKU, item.Description, item.Category, item.UnitCost, stock));
                }

                var result = new Result
                {
                    Stock = totalStock,
                    Value = totalValue,
                    Items = items
                };

                return result;
            }

            // TODO: Refactor this to separate class
            private int CalculateStock(IEnumerable<InventoryItemEntryDTO> entries)
            {
                var stock = 0;

                foreach (var entry in entries)
                {
                    if (entry.Type == "PURCHASE")
                    {
                        stock += entry.Quantity;
                    }
                    else if (entry.Type == "SALE")
                    {
                        stock -= entry.Quantity;
                    }
                }

                return stock;
            }

            private readonly ECommerceContext _db;
        }

        public class Result
        {
            public int Stock { get; set; }
            public decimal Value { get; set; }
            public List<InventoryItemDTO> Items { get; set; }
        }
    }
}
