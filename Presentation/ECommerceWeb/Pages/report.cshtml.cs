using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ECommerceWeb.Pages
{
    public class reportModel : PageModel
    {
        public string Message { get; set; }

        public void OnGet()
        {
            Message = "Here are the selling report:";
        }
    }
}