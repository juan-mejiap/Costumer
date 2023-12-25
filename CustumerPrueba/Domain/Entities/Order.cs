namespace Domain;
public class Order
{
    public int Id { get; set; }
    public DateTime FechaOrden { get; set; }
    public decimal MontoTotal { get; set; }
    public int CustomerId { get; set; }
    public Customer Customer { get; set; }

}
