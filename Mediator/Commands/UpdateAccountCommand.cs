using Bank.Service.Interfaces.Services;
using Domain.Entities;
using MediatR;

namespace Mediator.Commands
{
    public record UpdateAccountCommand(string IBAN, decimal Balance, int customerId, int cardId) : IRequest<Account>;

    public class UpdateAccountCommandHandler : IRequestHandler<UpdateAccountCommand, Account>
    {
        private readonly IAccountService _accountService;
        public UpdateAccountCommandHandler(IAccountService accountService)
        {
            _accountService = accountService;
        }
        public async Task<Account> Handle(UpdateAccountCommand request, CancellationToken cancellationToken)
        {
            var account = new Account();
            account.IBAN = request.IBAN;
            account.Balance = request.Balance;
            account.Customer.Id = request.customerId;
            account.Card.Id = request.cardId;

            _accountService.UpdateAccount(account);
            return await _accountService.GetAccount(account.Id);
        }
    }
}
