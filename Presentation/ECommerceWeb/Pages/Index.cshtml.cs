﻿using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using ECommerceApplication.Shopping.Product;
using ECommerceApplication.Shopping.Product.Queries;
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

        public async Task OnGetAsync()
        {
            var productResult = await _mediator.Send(new TopSellingProductsQuery.Request
            {
                NumberOfProducts = 12,
                Status = "Active"
            });

            ProductViews = Mapper.Map<List<ProductDTO>, List<ProductViewModel>>(productResult.Products);
        }

        private readonly IMediator _mediator;
    }
}