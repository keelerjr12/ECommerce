using System;
using System.Collections.Generic;
using System.Linq;
using ECommerceDomain.Sales.Cart;
using ECommerceDomain.Sales.Common;
using ECommerceDomain.Sales.Product;
using Xunit;

namespace ECommerceDomainTests
{
    public class CartTests
    {
        private readonly Cart _cart;

        private readonly List<Product> _inventory = new List<Product>()
        {
            new Product("0xasdgrasdf", "Sony", "Sony 65\" TV", 769.99m),
            new Product("0basdgasddg", "Samsung", "Samsung 80\" HDTV", 1349.99m)
        };

        public CartTests()
        {
            _cart = new Cart(0);
        }

        [Theory]
        [InlineData(0)]
        public void CreatingNewCart_SubTotal_EqualsZero(decimal expected)
        {
            var subtotal = _cart.Subtotal;

            Assert.Equal(expected, subtotal);
        }

        [Fact]
        public void CreatingNewCart_ItemCount_EqualsZero()
        {
            var count = _cart.ItemCount;

            Assert.Equal(Quantity.Zero, count);
        }

        [Theory]
        [InlineData(0, 1)]
        public void AddingSingleProductToCart_SubTotal_EqualsProductPrice(int productId, int quantity)
        {
            var product = _inventory[productId];

            _cart.Add(product, Quantity.Is(quantity));
            var subtotal = _cart.Subtotal;

            Assert.Equal(product.Price, subtotal);
        }

        [Theory]
        [InlineData(0, 1)]
        public void AddingSingleProductToCart_ItemCount_EqualsQuantity(int productId, int quantity)
        {
            var product = _inventory[productId];
            var expected = quantity;

            _cart.Add(product, Quantity.Is(quantity));
            var count = _cart.ItemCount;

            Assert.Equal(Quantity.Is(expected), count);
        }
        
        [Theory]
        [InlineData(0, 1)]
        public void AddingSingleProductToCart_ItemsList_ContainsAddedItem(int productId, int quantity)
        {
            var product = _inventory[productId];
            var expected = new List<Item>() { new Item(product, Quantity.Is(quantity)) };

            _cart.Add(product, Quantity.Is(quantity));
            var items = _cart.Items;

            Assert.Equal(expected, items);
        }
        
        [Theory]
        [InlineData(0, 1)]
        public void AddingSameProductTwice_SubTotal_EqualsDoubleTheProductPriceTimesQuantity(int productId, int quantity)
        {
            var product = _inventory[productId];
            var expected = 2 * product.Price * quantity;

            _cart.Add(product, Quantity.Is(quantity));
            _cart.Add(product, Quantity.Is(quantity));
            var subtotal = _cart.Subtotal;

            Assert.Equal(expected, subtotal);
        }

        [Theory]
        [InlineData(0, 1)]
        public void AddingSameProductTwice_SpecificItemCount_EqualsDoubleQuantity(int productId, int quantity)
        {
            var product = _inventory[productId];
            var expected = 2 * quantity;

            _cart.Add(product, Quantity.Is(quantity));
            _cart.Add(product, Quantity.Is(quantity));
            var itemCount = _cart.Items.ElementAt(0).Quantity;

            Assert.Equal(expected, itemCount.Value);
        }

        [Theory]
        [InlineData(0, 1, 1, 1)]
        public void AddingTwoDifferentProductsToCart_ItemCount_EqualsDoubleTheQuantity(int productId1, int productQuantity1, int productId2, int productQuantity2)
        {
            var product1 = _inventory[productId1];
            var product2 = _inventory[productId2];
            var expected = productQuantity1 + productQuantity2;

            _cart.Add(product1, Quantity.Is(productQuantity1));
            _cart.Add(product2, Quantity.Is(productQuantity2));
            var count = _cart.ItemCount;

            Assert.Equal(Quantity.Is(expected), count);
        }
        
        [Theory]
        [InlineData(0, 1, 1, 2)]
        public void AddingMultipleDifferentProductsToCart_ItemsList_ContainsAddedItems(int productId1, int productQuantity1, int productId2, int productQuantity2)
        {
            var product1 = _inventory[productId1];
            var product2 = _inventory[productId2];
            var expected = new List<Item>() { new Item(product1, Quantity.Is(productQuantity1)), new Item(product2, Quantity.Is(productQuantity2)) };

            _cart.Add(product1, Quantity.Is(productQuantity1));
            _cart.Add(product2, Quantity.Is(productQuantity2));
            var items = _cart.Items;

            Assert.Equal(expected, items);
        }

        [Theory]
        [InlineData(1, 1)]
        public void RemovingNonExistingItemFromCart_Throws_ItemNotFoundException(int productId, int quantity)
        {
            var product = _inventory[productId];

            Action action = () => _cart.Remove(product, Quantity.Is(quantity));

            Assert.Throws<ItemNotFoundException>(action);
        }
        /*
        [Theory]
        [InlineData(15, 0)]
        public void RemovingExistingItemFromCart_SubTotal_EqualsZero(decimal itemPrice, decimal expected)
        {
            var item = new Item(itemPrice);

            cart.AddItem(item);
            cart.RemoveItem(item);
            var subtotal = cart.Subtotal;

            Assert.Equal(expected, subtotal);
        }*/
    }
}
