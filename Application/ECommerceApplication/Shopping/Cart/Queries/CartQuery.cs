using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using ECommerceData;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ECommerceApplication.Shopping.Cart.Queries
{
    public class CartQuery
    {
        public class Request : IRequest<Result>
        {
            public Guid CustomerId { get; }

            public Request(Guid customerId)
            {
                CustomerId = customerId;
            }
        }

        public class Handler : IRequestHandler<Request, Result>
        {
            public Handler(ECommerceContext db)
            {
                _db = db;
            }
            
            // TODO: This logic should be in a library or view
            public async Task<Result> Handle(Request request, CancellationToken cancellationToken)
            {
                var cartItemDTOs = _db.CartItems.Include(p => p.Product).Where(cart => cart.CustomerId == request.CustomerId).ToListAsync().Result;

                var subtotal = 0m;
                var itemCount = 0;
                var items = new List<ItemDTO>();

                foreach (var item in cartItemDTOs)
                {
                    subtotal += item.Quantity * item.Product.Price;
                    itemCount += item.Quantity;

                    items.Add(new ItemDTO(item.Product.SKU, item.Product.Description, item.Quantity, item.Product.Price));
                }

                var result = new Result(itemCount, subtotal, items);
                return result;
            }

            private readonly ECommerceContext _db;
        }

        public class Result
        {
            public int ItemCount { get; }
            public decimal Subtotal { get; }
            public IEnumerable<ItemDTO> Items { get; }

            public Result(int itemCount, decimal subtotal, IEnumerable<ItemDTO> items)
            {
                ItemCount = itemCount;
                Subtotal = subtotal;
                Items = items;
            }
        }
    }
}
