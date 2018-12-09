using System;

namespace ECommerceDomain.Shopping.Cart
{
    public class ItemNotFoundException : Exception
    {
        public ItemNotFoundException(Product.Product product) : base($"{product.SKU} could not be found.")
        {
        }
    }
}
