using Bank.Service.Interfaces.Services;
using Infrastructure.DTO;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mediator.Queries
{
    public record GetAccountsQuery() : IRequest<IQueryable<Account>>;

    public class GetAccountsQueryHandler : IRequestHandler<GetAccountsQuery, IQueryable<Account>>
    {
        private readonly IAccountService _accountService;

        public GetAccountsQueryHandler(IAccountService accountService)
        {
            _accountService = accountService;

        }
        public async Task<IQueryable<Account>> Handle(GetAccountsQuery request, CancellationToken cancellationToken)
        {
            return await _accountService.GetAccounts();
            //await _customerService.SaveAsync(cancellationToken);
        }
    }
}
