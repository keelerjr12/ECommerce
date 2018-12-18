using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ECommerceApplication.Inventory.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ECommerceWeb.Areas.Account.Pages.Seller.Reports.Inventory
{
    public class InventoryReportModel : PageModel
    {
        public Dictionary<string, Dictionary<DateTime, int>> InventoryLevelViewModel { get; private set; } = new Dictionary<string, Dictionary<DateTime, int>>();

        public InventoryReportModel(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task OnGetAsync()
        {
            var result = await _mediator.Send(new InventoryItemLevelsByDateQuery.Request
            {
                ThroughDate = DateTime.Now
            });

            var firstDate = GetFirstDate(result.InventoryLevels);
            foreach (var pair in result.InventoryLevels)
            {
                InventoryLevelViewModel.Add(pair.Key, new Dictionary<DateTime, int>());

                for (var date = firstDate; date < DateTime.Now; date = date.AddMonths(1))
                {
                    var level = 0;

                    if (pair.Value.ContainsKey(date))
                    {
                        level = pair.Value[date];
                    }

                    InventoryLevelViewModel[pair.Key].Add(date, level);
                }
            }
        }

        private DateTime GetFirstDate(Dictionary<string, Dictionary<DateTime, int>> data)
        {
            var minDate = DateTime.Now;

            foreach (var d in data)
            {
                foreach (var dateLevelPair in d.Value)
                {
                    if (dateLevelPair.Key < minDate)
                    {
                        minDate = dateLevelPair.Key;
                    }
                }
            }

            return minDate;
        }

        private readonly IMediator _mediator;

    }
}