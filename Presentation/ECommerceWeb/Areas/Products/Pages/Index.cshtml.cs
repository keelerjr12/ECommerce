using System.Collections.Generic;
using AutoMapper;
using ECommerceApplication.Product;
using ECommerceApplication.Product.Queries;
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

        public List<ProductViewModel> Products { get; private set; }

        public IndexModel(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async void OnGetAsync()
        {
            var productResult = await _mediator.Send(new ProductsQuery.Request
            {
                Category = Category
            });

            Products = Mapper.Map<List<ProductDTO>, List<ProductViewModel>>(productResult.Products);
        }

        private readonly IMediator _mediator;
    }
}