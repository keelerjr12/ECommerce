using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using ECommerceApplication.Shopping.Product;
using ECommerceApplication.Shopping.Product.Queries;
using ECommerceWeb.Areas.Products.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ECommerceWeb.Pages
{
    public class SearchResultsModel : PageModel
    {
        [BindProperty(SupportsGet = true)]
        public string Query { get; set; }

        public List<ProductViewModel> ProductViews { get; private set; }

        public SearchResultsModel(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task OnGetAsync()
        {
            var productResult = await _mediator.Send(new ProductsBySearchTermsQuery.Request
            {
                Name = Query,
                Category = Query,
                Description = Query
            });

            ProductViews = Mapper.Map<List<ProductDTO>, List<ProductViewModel>>(productResult.Products);
        }

        private readonly IMediator _mediator;
    }
}