using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using ECommerceApplication.Shopping.Product;
using ECommerceApplication.Shopping.Product.Queries;
using ECommerceWeb.Areas.Products.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ECommerceWeb.Areas.Products.Pages
{
    public class IndexModel : PageModel
    {
        [BindProperty(SupportsGet = true)]
        public string Category { get; set; }

        [BindProperty(SupportsGet = true)]
        public int CategoryId { get; set; }

        public List<ProductViewModel> ProductViews { get; private set; }

        public IndexModel(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task OnGetAsync()
        {
            var productResult = await _mediator.Send(new ProductsQuery.Request
            {
                CategoryId = CategoryId
            });

            ProductViews = Mapper.Map<List<ProductDTO>, List<ProductViewModel>>(productResult.Products);
        }

        private readonly IMediator _mediator;
    }
}