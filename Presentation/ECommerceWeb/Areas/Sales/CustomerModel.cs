using ECommerceDomain.Sales.Customer;

namespace ECommerceWeb.Areas.Sales
{
    public class CustomerModel
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public string CityAndState { get; set; }
        public int ZipCode { get; set; }
   
        public CustomerModel(Customer customer)
        {
            Name = customer.FirstName + " " + customer.MiddleName + " " + customer.LastName;
            CityAndState = customer.City + ", " + customer.State;
            Address = customer.StreetAddress;
            ZipCode = customer.ZipCode;
        }
    }
}
