using Bank.Service;
using Bank.Service.Interfaces.Services;
using Infrastructure.DTO;
using MediatR;

namespace Mediator.Commands
{
    public record UpdateCustomerCommand(string FirstName, string LastName, string PersonalNumber, string Email) : IRequest<Customer>;

    public class UpdateCustomerCommandHandler : IRequestHandler<UpdateCustomerCommand, Customer>
    {
        private readonly ICustomerService _customerService;
        public UpdateCustomerCommandHandler(ICustomerService customerService)
        {
            _customerService = customerService;
        }
        public async Task<Customer> Handle(UpdateCustomerCommand request, CancellationToken cancellationToken)
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
}
