namespace ECommerceDomain.Common
{
    public class Address
    {
        public string Street { get; }
        public string City { get; }
        public string State { get; }
        public string Country { get; }
        public int Zipcode { get; }

        public Address(string street, string city, string state, string country, int zipcode)
        {
            Street = street;
            City = city;
            State = state;
            Country = country;
            Zipcode = zipcode;
        }
    }
}
