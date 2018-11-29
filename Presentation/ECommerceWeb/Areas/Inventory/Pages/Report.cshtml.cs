using System;
using ECommerceApplication.Reporting;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ECommerceWeb.Areas.Inventory.Pages
{
    public class ReportModel : PageModel
    {
        public int Stock { get; private set; }

        public ReportModel(InventoryLevelReport report)
        {
            _report = report;
        }

        public void OnGet()
        {
            Stock = _report.LevelByDate("1", DateTime.Now);
        }

        private readonly InventoryLevelReport _report;
    }
}