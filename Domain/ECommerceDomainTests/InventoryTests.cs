using Xunit;

namespace ECommerceDomainTests
{
    public class InventoryTests
    {
        public InventoryTests()
        {
            //_inventory = new Inventory(1, null);
            //_inventory.TrackProduct(_product);
        }

        [Theory]
        [InlineData(1)]
        [InlineData(2)]
        public void PurchaseSingleProductWithVariableQuantity_ItemCount_EqualsQuantity(int quantity)
        {
           // _inventory.Purchase(_product, quantity);

           // Assert.Equal(quantity, _inventory.ItemCount);
        }
        /*
        [Theory]
        [InlineData(1, 2)]
        public void PurchaseSingleProductMultipleTimesWithVariableQuantity_ItemCount_EqualsQuantity(int quantity1, int quantity2)
        {
            _inventory.Purchase(_product, quantity1);
            _inventory.Purchase(_product, quantity2);
            var expected = quantity1 + quantity2;

            Assert.Equal(expected , _inventory.ItemCount);
        }
        
        [Theory]
        [InlineData("1", 1)]
        public void PurchaseProductNotTracked_Inventory_ThrowsException(string sku, int quantity)
        {
            Action action = () => _inventory.Purchase(new Product(sku, "", "", 10.99m), quantity);

            Assert.Throws<Exception>(action);
        }

        [Theory]
        [InlineData(1)]
        [InlineData(2)]
        public void SellSingleProductWithVariableQuantity_ItemCount_EqualsNegativeQuantity(int quantity)
        {
            _inventory.Sell(_product, quantity);
            var expected = -1 * quantity;

            Assert.Equal(expected, _inventory.ItemCount);
        }

        [Theory]
        [InlineData(1, 2)]
        public void SellSingleProductMultipleTimesWithVariableQuantity_ItemCount_EqualsZero(int quantity1, int quantity2)
        {
            _inventory.Sell(_product, quantity1);
            _inventory.Sell(_product, quantity2);
            var expected = -1 * (quantity1 + quantity2);

            Assert.Equal(expected, _inventory.ItemCount);
        }

        [Theory]
        [InlineData("1", 1)]
        public void SellProductNotTracked_Inventory_ThrowsException(string sku, int quantity)
        {
            Action action = () => _inventory.Sell(new Product(sku, "", "", 199m), quantity);

            Assert.Throws<Exception>(action);
        }

        [Theory]
        [InlineData("1")]
        public void UntrackProductThatDoesNotExist_Inventory_ThrowsException(string sku)
        {
            //Action action = () => _inventory.UntrackProduct(new Product(sku, "", "", 199m));

            //Assert.Throws<Exception>(action);
        }
                
        [Fact]
        public void GetInventoryStockOfSpecificSKUOnPurchaseDate_Stock_ReturnsQuantity()
        {
            var date = new DateTime(2018, 1, 1);
            _inventory.Purchase("1", 1, date);

            var stock = _inventory.StockByDate("1", date);
        }
        
        private readonly Inventory _inventory;
        private readonly Product _product = new Product("0", "", "", 199m);*/
    }
}
