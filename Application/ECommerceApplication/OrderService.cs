using ECommerceData;
using ECommerceDomain.Sales.Cart;
using ECommerceDomain.Sales.Customer;
using ECommerceDomain.Sales.Order;

namespace ECommerceApplication
{
    public class OrderService
    {
        public OrderService(UnitOfWork uow, ICustomerRepository customerRepo, ICartRepository cartRepo, IOrderRepository orderRepo)
        {
            _uow = uow;
            _customerRepo = customerRepo;
            _cartRepo = cartRepo;
            _orderRepo = orderRepo;
        }

        public void PlaceOrder(int customerId)
        {
            var customer = _customerRepo.GetById(customerId);
            var cart = _cartRepo.FindById(customerId);
            var items = cart.Checkout();

            var order = new Order(customer, items);

            _orderRepo.Create(order);

            _uow.Save();
        }

        private readonly UnitOfWork _uow;
        private readonly ICustomerRepository _customerRepo;
        private readonly ICartRepository _cartRepo;
        private readonly IOrderRepository _orderRepo;
    }
}
