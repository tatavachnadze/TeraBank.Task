using Bank.Service.Interfaces.Services;
using MediatR;

namespace Mediator.Commands
{
    public record SuspendAccountCommand(int Id) : IRequest;

    public class SuspendAccountCommandHandler : IRequestHandler<SuspendAccountCommand>
    {
        private readonly IAccountService _accountService;
        public SuspendAccountCommandHandler(IAccountService accountService)
        {
            _accountService = accountService;
        }
        public async Task Handle(SuspendAccountCommand request, CancellationToken cancellationToken)
        {
            await Task.Run(() => { _accountService.SuspendAccount(request.Id); }, cancellationToken);
        }
    }
}
