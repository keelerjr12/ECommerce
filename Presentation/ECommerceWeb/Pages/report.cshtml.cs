using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

//https://www.c-sharpcorner.com/UploadFile/f82e9a/data-displaying-in-table-format-in-diffrent-ways-in-mvc/
namespace ECommerceWeb.Pages
{

    public class sales
    {
        public string inventory_levels { get; set; }
        public string inventory_costs { get; set; }
        public string customer_lists { get; set; }
        public string montly_cost { get; set; }
    }
    public class reportModel : PageModel
    {
        public string Message { get; set; }
        public string inventory_levels { get; set; }
        public string inventory_costs { get; set; }
        public string customer_lists { get; set; }
        public string montly_cost { get; set; }
        public void OnGet()
        {
            Message = "Here is the selling report:";
            inventory_levels = "mother braclets";
            inventory_costs = "1300.00$";
            customer_lists = "Charles";
            montly_cost = "3000,00$";
        }
    }

    public class HomeController : PageModel
    {
        private List<sales> emp;
        public string Message { get; set; }
        public void OnGet()
        {
            Message = "Here is the selling report:";
        }
        public HomeController()
        {
            emp = new List<sales>()
        {
            new sales()
            { inventory_levels="Rakesh",inventory_costs="Kalluri", customer_lists="raki.kalluri@gmail.com", montly_cost="30000"},
            new sales()
            { inventory_levels="Rakesh",inventory_costs="Kalluri", customer_lists="raki.kalluri@gmail.com", montly_cost="30000"},
        };
        }

    }
}




