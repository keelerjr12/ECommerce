using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using ECommerceData;
using ECommerceData.Inventory.Inventory;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query.Internal;

namespace ECommerceApplication.Inventory.Queries
{
    public class InventoryItemLevelsByDateQuery
    {
        public class Request : IRequest<Result>
        {
            public DateTime StartDate { get; set; }
            public DateTime EndDate { get; set; }
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
                        ProductInventoryLevel {
                            SKU = i.Product.SKU,
                            EntriesByMonth = i.Entries
                                .Where(e => request.StartDate <= e.DateOccurred && e.DateOccurred <= request.EndDate)
                                .GroupBy(e => new DateTime(e.DateOccurred.Year, e.DateOccurred.Month, 1))
                                .ToList()
                        }
                    ).ToList();

                var months = new List<DateTime>();
                for (var date = request.StartDate; date < request.EndDate; date = date.AddMonths(1))
                {
                    months.Add(date);
                }

                var inventoryLevels = new Dictionary<string, Dictionary<DateTime, int>>();
                foreach (var item in items)
                {
                    inventoryLevels.Add(item.SKU, new Dictionary<DateTime, int>());
                    var inventory = 0;

                    foreach (var month in months)
                    {
                        foreach (var grouping in item.EntriesByMonth)
                        {
                            if (grouping.Key != month)
                                continue;

                            foreach (var entry in grouping)
                            {
                                switch (entry.Type)
                                {
                                    case "PURCHASE":
                                        inventory += entry.Quantity;
                                        break;
                                    case "SALE":
                                        inventory -= entry.Quantity;
                                        break;
                                    default:
                                        throw new Exception("Unexpected Case");
                                }
                            }
                        }

                        inventoryLevels[item.SKU].Add(new DateTime(month.Year, month.Month, 1), inventory);
                    }
                }

                return new Result { InventoryLevels = inventoryLevels};
            }

            private class ProductInventoryLevel
            {
                public string SKU { get; set; }
                public List<IGrouping<DateTime, InventoryItemEntryDTO>> EntriesByMonth { get; set; }
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
