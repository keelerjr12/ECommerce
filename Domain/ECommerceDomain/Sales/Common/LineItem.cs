namespace ECommerceDomain.Sales.Common
{
    public class LineItem
    {
        private int productId;
        private int value;

        public LineItem(int productId, int value)
        {
            this.productId = productId;
            this.value = value;
        }
    }
}