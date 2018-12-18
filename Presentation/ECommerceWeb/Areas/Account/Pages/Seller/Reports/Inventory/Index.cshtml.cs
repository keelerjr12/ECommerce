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
        public Dictionary<string, Dictionary<DateTime, int>> InventoryLevelViewModel { get; private set; }

        public InventoryReportModel(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task OnGetAsync()
        {
            var result = await _mediator.Send(new InventoryItemLevelsByDateQuery.Request
            {
                StartDate = new DateTime(DateTime.Now.Year, 1, 1),
                EndDate = DateTime.Now
            });

            InventoryLevelViewModel = result.InventoryLevels;
        }

        private readonly IMediator _mediator;

    }
}