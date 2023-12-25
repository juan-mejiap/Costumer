namespace Domain;
public interface IOrderRepository
{
    IEnumerable<Order> GetOrders();
    Order GetOrderById(int orderId);
    void SaveOrder(Order order);
}