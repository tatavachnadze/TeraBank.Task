using Bank.Service;
using Bank.Service.Interfaces.Services;
using Infrastructure.DTO;
using Mediator.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace TeraBank.API.Controllers
{
    public class CustomerController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly ILogger<CustomerController> _logger;

        public CustomerController(IMediator mediator, ILogger<CustomerController> logger)
        {
            _logger = logger;
            _mediator = mediator;
        }

        [HttpGet("{id:int}")]
        public Task<Customer> GetCustomer(int id)
        {
            var customer = _mediator.GetCustomer(id);
            if (customer == null)
            {
                throw new ArgumentNullException($"The item with given Id: {nameof(id)} could not be found.");
            }
            return customer;
        }

        [HttpGet]
        public async Task<IActionResult> GetCustomers()
        {
          var customers = await _mediator.Send(new GetCustomersQuery());
          return Ok(customers);
        }

    }
}
