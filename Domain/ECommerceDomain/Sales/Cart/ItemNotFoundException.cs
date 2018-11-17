using System;

namespace ECommerceDomain.Sales.Cart
{
    public class ItemNotFoundException : Exception
    {
        public ItemNotFoundException(Product.Product product) : base(string.Format("{0} could not be found.", product.SKU))
        {
        }
    }
}
