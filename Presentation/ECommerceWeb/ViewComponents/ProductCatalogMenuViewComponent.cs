using System.Collections.Generic;
using System.Threading.Tasks;
using ECommerceApplication.Shopping.ProductCategory.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ECommerceWeb.ViewComponents
{
    public class ProductCatalogMenuViewComponent : ViewComponent
    {
        public ProductCatalogMenuViewComponent(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var categories = _mediator.Send(new AllProductCategoriesQuery.Request()).Result.ProductCategories;

            return View(categories);
        }

        private readonly IMediator _mediator;
    }
}
