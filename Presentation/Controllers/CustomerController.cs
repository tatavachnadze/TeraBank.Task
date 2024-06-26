﻿using Mediator.Commands;
using Mediator.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using TeraBank.API.Models;

namespace Presentation.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CustomerController : ControllerBase
    {
        private readonly IMediator _mediator;
        public CustomerController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetCustomer(int id)
        {
           var customer = await _mediator.Send(new GetCustomerQuery(id));
            return Ok(customer);    
        }

        [HttpGet]
        public async Task<IActionResult> GetCustomers()
        {
          var customers = await _mediator.Send(new GetCustomersQuery());
          return Ok(customers);
        }

        [HttpPost]
        public async Task<IActionResult> AddCustomer([FromBody] CustomerModel customerModel)
        {
            var customer = await _mediator.Send(new AddCustomerCommand(customerModel.FirstName, customerModel.Lastname, customerModel.PersonalNumber, customerModel.Email));
            return Ok(customer);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateCustomer([FromBody] CustomerModel customerModel)
        {
            var customer = await _mediator.Send(new UpdateCustomerCommand(customerModel.FirstName, customerModel.Lastname, customerModel.PersonalNumber, customerModel.Email));
            return Ok(customer);
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteCustomer(int id)
        {
            await _mediator.Send(new DeleteCustomerCommand(id));
            return Ok();
        }
    }
}
