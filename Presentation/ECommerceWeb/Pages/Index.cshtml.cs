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
<<<<<<< HEAD
                NumberOfProducts = 12
            });
=======
                var productVM = new ProductViewModel
                {
                    SKU = prod.SKU,
                    Description = prod.Description,
                    Price = prod.Price,
                    CategoryId = prod.CategoryId
                };

                Products.Add(productVM);
            }
        }

        public IActionResult OnPost(string sku)
        {
            _cartService.AddProductToCart(1, sku, 1);
>>>>>>> d6bebe82ac751b7ad10b8d996b993174c2f29f91

            ProductViews = Mapper.Map<List<ProductDTO>, List<ProductViewModel>>(productResult.Products);
        }

        private readonly IMediator _mediator;
    }
}
