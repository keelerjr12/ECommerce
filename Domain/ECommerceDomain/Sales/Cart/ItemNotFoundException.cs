using System;

namespace ECommerceDomain.Sales.Cart
{
    public class ItemNotFoundException : Exception
    {
        public ItemNotFoundException(Product.Product product) : base($"{product.SKU} could not be found.")
        {
        }
    }
}
