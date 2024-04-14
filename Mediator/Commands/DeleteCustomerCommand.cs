using Bank.Service.Interfaces.Services;
using MediatR;

namespace Mediator.Commands
{
    public record DeleteCustomerCommand(int Id) : IRequest; // customer-s abrunebs anu

    public class DeleteCustomerCommandHandler : IRequestHandler<DeleteCustomerCommand>
    {
        private readonly ICustomerService _customerService;
        public DeleteCustomerCommandHandler(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        public async Task Handle(DeleteCustomerCommand request, CancellationToken cancellationToken)
        {
            await Task.Run(() => { _customerService.DeleteCustomer(request.Id); }, cancellationToken);
        }
    }
}
