using Bank.Service;
using Bank.Service.Interfaces.Repositories;
using Bank.Service.Interfaces.Services;
using Infrastructure.DTO;
using MediatR;


namespace Mediator.Commands;

public record AddCustomerCommand(Customer customer) /*string FirstName, string LastName, string Gender, string PersonalNumber, string Email*/
        : IRequest<Customer>; // customer-s abrunebs anu

public class AddCustomerCommandHandler : IRequestHandler<AddCustomerCommand, Customer>
{
    private readonly ICustomerService _customerService;

    public AddCustomerCommandHandler(ICustomerService customerService)
    {
        _customerService = customerService;

    }

    public async Task<Customer> Handle(AddCustomerCommand request, CancellationToken cancellationToken)
    {
        await _customerService.AddCustomer(request);


        await _customerService.SaveAsync(cancellationToken);

    }
}


