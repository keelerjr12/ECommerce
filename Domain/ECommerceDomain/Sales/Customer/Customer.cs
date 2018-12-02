namespace ECommerceDomain.Sales.Customer
{
    public class Customer
    {
        public int Id { get; }

        public string FirstName { get; }
        public string MiddleName { get; }
        public string LastName { get; }
        public string StreetAddress { get; }
        public string City { get; }
        public string State { get; }
        public string Country { get; }
        public int ZipCode { get;  }

        public Customer(int id, string firstName, string middleName, string lastName, string streetAddress, string city, string state, string country, int zipCode)
        {
            Id = id;
            FirstName = firstName;
            MiddleName = middleName;
            LastName = lastName;
            StreetAddress = streetAddress;
            City = city;
            State = state;
            Country = country;
            ZipCode = zipCode;
        }
    }
}
