// Presentation Layer
using Microsoft.AspNetCore.Mvc;
using System;
using Application;
using Domain;

namespace Controllers;

[ApiController]
[Route("api/[controller]")]
public class CustomerController : ControllerBase
{
    private readonly ICustomerRepository _customerRepository;
    private readonly OrderService _orderService;

    public CustomerController(ICustomerRepository customerRepository, OrderService orderService)
    {
        _customerRepository = customerRepository;
        _orderService = orderService;
    }

    [HttpGet]
    public IActionResult GetCustomers()
    {
        var customers = _customerRepository.GetCustomers();
        return Ok(customers);
    }

    [HttpGet("{customerId}")]
    public IActionResult GetCustomerById(int customerId)
    {
        var customer = _customerRepository.GetCustomerById(customerId);

        if (customer == null)
        {
            return NotFound();
        }
        return Ok(customer);
    }

    [HttpPost]
    public IActionResult CreateCustomer([FromBody] Customer newCustomer)
    {
        if (newCustomer == null)
        {
            return BadRequest();
        }
        _customerRepository.Save(newCustomer);
        return CreatedAtAction(nameof(GetCustomerById), new { customerId = newCustomer.Id }, newCustomer);
    }
}

