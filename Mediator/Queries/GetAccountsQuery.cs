using Bank.Service.Interfaces.Services;
using Domain.Entities;
using MediatR;

namespace Mediator.Queries
{
    public record GetAccountsQuery() : IRequest<IQueryable<Account>>;

    public class GetAccountsQueryHandler : IRequestHandler<GetAccountsQuery, IEnumerable<Account>>
    {
        private readonly IAccountService _accountService;

        public GetAccountsQueryHandler(IAccountService cardService)
        {
            _accountService = cardService;

        }
        public async Task<IEnumerable<Account>> Handle(GetAccountsQuery request, CancellationToken cancellationToken)
        {
            return await _accountService.GetAccounts();
            //await _customerService.SaveAsync(cancellationToken);
        }
    }
}
