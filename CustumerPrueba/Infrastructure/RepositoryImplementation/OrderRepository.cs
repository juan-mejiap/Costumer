using Domain;

namespace Infrastructure;

public class OrderRepository : IOrderRepository
{
    private readonly AppDbContext _dbContext;

    public OrderRepository(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    public IEnumerable<Order> GetOrders()
    {
        return _dbContext.Orders.ToList();
    }

    public Order GetOrderById(int OrderId)
    {
        return _dbContext.Orders.FirstOrDefault(c => c.Id == OrderId);
    }

    public void SaveOrder(Order Order)
    {
        if (Order.Id == 0)
        {
            _dbContext.Orders.Add(Order);
        }
        else
        {
            _dbContext.Orders.Update(Order);
        }
        _dbContext.SaveChanges();
    }

    public void CancelOrder(Order  order){
        _dbContext.Orders.Remove(order);
        _dbContext.SaveChanges();
    }
}