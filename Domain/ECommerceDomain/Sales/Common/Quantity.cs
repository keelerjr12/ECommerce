namespace ECommerceDomain.Sales.Common
{
    public class Quantity
    {

        public int Value { get; }

        public static Quantity Zero => new Quantity(0);

        public static Quantity Is(int value)
        {
            return new Quantity(value);
        }

        public static Quantity operator +(Quantity lhs, Quantity rhs)
        {
            return new Quantity(lhs.Value + rhs.Value);
        }

        public static Quantity operator -(Quantity lhs, Quantity rhs)
        {
            return new Quantity(lhs.Value - rhs.Value);
        }

        public override bool Equals(object obj)
        {
            return Equals(obj as Quantity);
        }

        public static bool operator ==(Quantity lhs, Quantity rhs)
        {
            if (ReferenceEquals(lhs, null))
            {
                if (ReferenceEquals(rhs, null))
                {
                    return true;
                }

                return false;
            }

            return lhs.Equals(rhs);
        }

        public static bool operator !=(Quantity lhs, Quantity rhs)
        {
            return !(lhs == rhs);
        }

        public override int GetHashCode()
        {
            return Value.GetHashCode();
        }

        public override string ToString()
        {
            return Value.ToString();
        }

        private Quantity(int value)
        {
            if (value < 0)
                throw new QuantityLessThanZeroException(value);

            Value = value;
        }

        private bool Equals(Quantity other)
        {

            if (ReferenceEquals(other, null))
            {
                return false;
            }

            if (ReferenceEquals(this, other))
            {
                return true;
            }

            if (GetType() != other.GetType())
            {
                return false;
            }

            return Value == other.Value;
        }
    }
}
