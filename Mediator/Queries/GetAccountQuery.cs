using Bank.Service.Interfaces.Services;
using Domain.Entities;
using MediatR;

namespace Mediator.Queries
{
    public record GetAccountQuery(int Id) : IRequest<Account>;

    public class GetAccountQueryHandler : IRequestHandler<GetAccountQuery, Account>
    {
        private readonly IAccountService _accountService;

        public GetAccountQueryHandler(IAccountService accountService)
        {
            _accountService = accountService;

        }
        public async Task<Account> Handle(GetAccountQuery request, CancellationToken cancellationToken)
        {
            return await _accountService.GetAccount(request.Id);
            //await _customerService.SaveAsync(cancellationToken);
        }
    }
}
