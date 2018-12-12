using System.Collections.Generic;
using AutoMapper;
using ECommerceApplication.Product;
using ECommerceApplication.Product.Queries;
using ECommerceWeb.Areas.Products.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MediatR;

namespace ECommerceWeb.Pages
{
    public class IndexModel : PageModel
    {
        public List<ProductViewModel> ProductViews { get; private set; }

        public IndexModel(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async void OnGetAsync()
        {
            var productResult = await _mediator.Send(new TopSellingProductsQuery.Request
            {
                NumberOfProducts = 12
            });

            ProductViews = Mapper.Map<List<ProductDTO>, List<ProductViewModel>>(productResult.Products);
        }

        private readonly IMediator _mediator;
    }
}