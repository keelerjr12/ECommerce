using System;

namespace ECommerceDomain.Sales.Common
{
    public class QuantityLessThanZeroException : Exception
    {
        public QuantityLessThanZeroException(int value) : base(string.Format("Cannot set quantity to {0}. Quantity cannot be less than 0.", value))
        {
        }
    }
}
