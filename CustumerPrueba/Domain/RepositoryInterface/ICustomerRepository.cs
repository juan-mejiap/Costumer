namespace Domain;
public interface ICustomerRepository
{
    IEnumerable<Customer> GetCustomers();
    Customer GetCustomerById(int customerId);
    void Save(Customer customer);
    void DeleteCustomer(Customer  customer);
}