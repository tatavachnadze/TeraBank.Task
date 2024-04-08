using Bank.Service.Interfaces.Services;
using Infrastructure.DTO;
using MediatR;


namespace Mediator.Commands;

public record AddCustomerCommand(string FirstName, string LastName, string PersonalNumber, string Email) : IRequest<Customer>; // customer-s abrunebs anu

public class AddCustomerCommandHandler : IRequestHandler<AddCustomerCommand, Customer>
{
    private readonly ICustomerService _customerService;

    public AddCustomerCommandHandler(ICustomerService customerService)
    {
        _customerService = customerService;
    }

    public async Task<Customer> Handle(AddCustomerCommand request, CancellationToken cancellationToken)
    {
        var customer = new Customer();
        customer.FirstName = request.FirstName;
        customer.LastName = request.LastName;
        customer.PersonalNumber = request.PersonalNumber;
        customer.Email = request.Email;

        _customerService.UpdateCustomer(customer);
        return await _customerService.GetCustomer(customer.Id);
    }
}


