// Agrega los using necesarios según tu entorno de pruebas
using NUnit.Framework;
using Moq;
using Domain;
using Application;

namespace TuProyecto.Tests
{
    [TestFixture]
    public class OrderServiceTests
    {
        [Test]
        public void CreateOrder_ShouldCreateOrderSuccessfully()
        {
            var mockOrderRepository = new Mock<IOrderRepository>();
            var mockCustomerRepository = new Mock<ICustomerRepository>(); 

            var orderService = new OrderService(mockOrderRepository.Object, mockCustomerRepository.Object);

            var customer = new Customer
            {
                Id = 1,
                Nombre = "NombreCliente",
                Apellido = "ApellidoCliente",
                Email = "cliente@example.com"
            };

            var fechaOrden = DateTime.Now;
            var montoTotal = 100.00m;
            orderService.CreateOrder(customer, fechaOrden, montoTotal);

            mockOrderRepository.Verify(r => r.SaveOrder(It.IsAny<Order>()), Times.Once);
        }

        
    }
}
