using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using ECommerceData;
using MediatR;

namespace ECommerceApplication.Inventory.Queries
{
    public class InventoryItemLevelsByDateQuery
    {
        public class Request : IRequest<Result>
        {
            public DateTime ThroughDate { get; set; }
        }

        public class Handler : IRequestHandler<Request, Result>
        {

            public Handler(ECommerceContext db)
            {
                _db = db;
            }

            public async Task<Result> Handle(Request request, CancellationToken cancellationToken)
            {
                var items = _db.InventoryItems
                    .Select(i => new
                        {
                            i.Product.SKU,
                            Entries = i.Entries
                                .Where(e => e.DateOccurred <= request.ThroughDate)
                                .GroupBy(e => new DateTime(e.DateOccurred.Year, e.DateOccurred.Month, 1))
                                .ToList()
                        }
                    );

                var inventoryLevels = new Dictionary<string, Dictionary<DateTime, int>>();

                foreach (var item in items)
                {
                    inventoryLevels.Add(item.SKU, new Dictionary<DateTime, int>());

                    foreach (var monthGrouping in item.Entries)
                    {
                        var inventory = 0;

                        foreach (var entry in monthGrouping)
                        {
                            if (entry.Type == "PURCHASE")
                            {
                                inventory += entry.Quantity;
                            }
                            else if (entry.Type == "SELL")
                            {
                                inventory -= entry.Quantity;
                            }
                        }

                        inventoryLevels[item.SKU]
                            .Add(new DateTime(monthGrouping.Key.Year, monthGrouping.Key.Month, monthGrouping.Key.Day),
                                inventory);
                    }
                }

                return new Result { InventoryLevels = inventoryLevels};
            }

            private readonly ECommerceContext _db;
        }

        public class Result
        {
            public Dictionary<string, Dictionary<DateTime, int>> InventoryLevels
            {
                get; set;
            }
        }
    }
}
