using System;

namespace ECommerceDomain.Sales.Common
{
    public class QuantityLessThanZeroException : Exception
    {
        public QuantityLessThanZeroException(int value) : base(
            $"Cannot set quantity to {value}. Quantity cannot be less than 0.")
        {
        }
    }
}
