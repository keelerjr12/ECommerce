using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using ECommerceApplication.Shopping.Cart.Commands;
using ECommerceApplication.Shopping.Cart.Queries;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ECommerceWeb.Areas.Sales.Models;
using MediatR;

namespace ECommerceWeb.Areas.Sales.Pages
{
    public class CartModel : PageModel
    {
        public int ItemCount { get; private set; }

        public decimal Subtotal { get; private set; }

        public List<CartItemModel> Items { get; } = new List<CartItemModel>();

        public CartModel(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task OnGetAsync()
        {
            var customerId = Guid.Parse(User.Claims.First(a => a.Type == ClaimTypes.NameIdentifier).Value);

            var result = await _mediator.Send(new CartQuery.Request(customerId));

            ItemCount = result.ItemCount;
            Subtotal = result.Subtotal;


            // TODO: Move into viewmodel
            var sortedItems = result.Items.OrderBy(item => item.Description);

            foreach (var item in sortedItems)
            {
                Items.Add(new CartItemModel(item.SKU, item.Description, item.Quantity, item.Price));
            }
        }

        public async Task<IActionResult> OnPostAddAsync(string sku)
        {
            var customerId = Guid.Parse(User.Claims.First(a => a.Type == ClaimTypes.NameIdentifier).Value);

            await _mediator.Send(new AddProductToCartCommand.Request(customerId, sku, 1));

            return RedirectToPage();
        }

        public async Task<IActionResult> OnPostRemoveAsync(string sku)
        {
            var customerId = Guid.Parse(User.Claims.First(a => a.Type == ClaimTypes.NameIdentifier).Value);

            await _mediator.Send(new RemoveProductFromCartCommand.Request(customerId, sku, 1));

            return RedirectToPage();
        }

        private readonly IMediator _mediator;
    }
}