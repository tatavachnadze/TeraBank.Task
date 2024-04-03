using Bank.Service;
using Bank.Service.Interfaces.Services;
using Infrastructure.DTO;
using MediatR;

namespace Mediator.Commands
{
    public record CreateAccountCommand(string IBAN, decimal Balance, int customerId, int cardId) : IRequest<Account>;

    public class CreateAccountCommandHandler : IRequestHandler<CreateAccountCommand, Account>
    {
        private readonly IAccountService _accountService;
        public CreateAccountCommandHandler(IAccountService accountService)
        {
            _accountService = accountService;
        }
        public async Task<Account> Handle(CreateAccountCommand request, CancellationToken cancellationToken)
        {
            var account = new Account();
            account.IBAN = request.IBAN;
            account.Balance= request.Balance;
            account.Customer.Id = request.customerId;
            account.Card.Id = request.cardId;

            _accountService.CreateAccount(account);
            return await _accountService.GetAccount(account.Id);
        }
    }
}
