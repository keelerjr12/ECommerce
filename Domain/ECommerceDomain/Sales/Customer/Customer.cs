namespace ECommerceDomain.Sales.Customer
{
    public class Customer
    {
        public int Id { get; }
        public string FirstName;
        public string MiddleName;
        public string LastName;
        public string StreetAddress;
        public int ZipCode;

        public Customer(int id, string firstName, string middleName, string lastName, string streetAddress, int zipCode)
        {
            Id = id;
            FirstName = firstName;
            MiddleName = middleName;
            LastName = lastName;
            StreetAddress = streetAddress;
            ZipCode = zipCode;
        }
    }
}
