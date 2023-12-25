using Domain;
namespace Application;

public class OrderService
{
    private readonly IOrderRepository _orderRepository;
    private readonly ICustomerRepository _customerRepository;

    public OrderService(IOrderRepository orderRepository, ICustomerRepository customerRepository)
    {
        _orderRepository = orderRepository ;
        _customerRepository = customerRepository;
    }
    
    public void CreateOrder(Customer customer, DateTime fechaOrden, decimal montoTotal)
    {
        var newOrder = new Order
        {
            FechaOrden = fechaOrden,
            MontoTotal = montoTotal,
            CustomerId = customer.Id
        };
        _orderRepository.SaveOrder(newOrder);
    }

     public void CancelOrder(int orderId)
        {
           var order = _orderRepository.GetOrderById(orderId);

        if (order == null)
        {
            throw new InvalidOperationException($"No se encontró la orden con ID {orderId}");
        }
        _orderRepository.CancelOrder(order);
        }
}

