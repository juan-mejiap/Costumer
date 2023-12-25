// Application/Use Case Layer
using Domain;
namespace Application;

public class OrderService
{
    private readonly IOrderRepository _orderRepository;
    private readonly ICustomerRepository _customerRepository;

    // Constructor que recibe las instancias de los repositorios necesarios
    public OrderService(IOrderRepository orderRepository, ICustomerRepository customerRepository)
    {
        _orderRepository = orderRepository ;
        _customerRepository = customerRepository;
    }

    // Método para crear una orden para un cliente específico
    public void CreateOrder(Customer customer, DateTime fechaOrden, decimal montoTotal)
    {
        // Puedes realizar lógica adicional aquí antes de crear la orden

        // Crear una nueva orden
        var newOrder = new Order
        {
            FechaOrden = fechaOrden,
            MontoTotal = montoTotal,
            CustomerId = customer.Id
        };

        // Guardar la orden en el repositorio
        _orderRepository.SaveOrder(newOrder);
    }

     public void CancelOrder(Order order)
        {
            // Puedes realizar lógica adicional aquí antes de cancelar la orden

            // Cambiar el estado de la orden a "cancelada"
            //order.OrderStatus = OrderStatus.Cancelada;

            // Actualizar la orden en el repositorio
            _orderRepository.SaveOrder(order);
        }
}

