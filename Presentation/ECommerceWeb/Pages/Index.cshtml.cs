using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using ECommerceApplication.ProductService;
using ECommerceWeb.Areas.Products.Pages;
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

        public async Task OnGetAsync()
        {
            var productResult = await _mediator.Send(new TopSellingProductsQuery
            {
                NumberOfProducts = 12
            });

            ProductViews = Mapper.Map<List<ProductDTO>, List<ProductViewModel>>(productResult.Products);
        }

        private readonly IMediator _mediator;
    }
}
