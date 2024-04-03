using Bank.Service;
using Bank.Service.Interfaces.Services;
using MediatR;

namespace Mediator.Commands
{
    public record DeleteAccountCommand(int Id) : IRequest;

    public class DeleteAccountCommandHandler : IRequestHandler<DeleteAccountCommand>
    {
        private readonly IAccountService _accountService;
        public DeleteAccountCommandHandler(IAccountService accountService)
        {
            _accountService = accountService;
        }
        public async Task Handle(DeleteAccountCommand request, CancellationToken cancellationToken)
        {
            await Task.Run(() => { _accountService.DeleteAccount(request.Id); }, cancellationToken);
        }
    }
}
