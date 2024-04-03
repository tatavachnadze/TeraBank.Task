using Bank.Service.Interfaces.Services;
using MediatR;

namespace Mediator.Commands
{
    public record ResumeAccountCommand(int Id) : IRequest;
    public class ResumeAccountCommandHandler : IRequestHandler<ResumeAccountCommand>
    {
        private readonly IAccountService _accountService;
        public ResumeAccountCommandHandler(IAccountService accountService)
        {
            _accountService = accountService;
        }
        public async Task Handle(ResumeAccountCommand request, CancellationToken cancellationToken)
        {
            await Task.Run(() => { _accountService.ResumeAccount(request.Id); }, cancellationToken);
        }
    }
}
