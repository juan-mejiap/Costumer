using Domain;

namespace Infrastructure;

public class CustomerRepository : ICustomerRepository
{
    private readonly AppDbContext _dbContext;

    public CustomerRepository(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    public IEnumerable<Customer> GetCustomers()
    {
        return _dbContext.Customers.ToList();
    }

    public Customer GetCustomerById(int customerId)
    {
        return _dbContext.Customers.FirstOrDefault(c => c.Id == customerId);
    }

    public void Save(Customer customer)
    {
        if (customer == null)
        {
            Console.WriteLine("Datos del cliente no válidos");
        }

        _dbContext.Customers.Add(customer);
        _dbContext.SaveChanges();

        
    }

}

