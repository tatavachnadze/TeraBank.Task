using Bank.Service;
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
    public record GetTransactionsQuery() : IRequest<IQueryable<Transaction>>;

    public class GetTransactionsQueryHandler : IRequestHandler<GetTransactionsQuery, IQueryable<Transaction>>
    {
        private readonly ITransactionService _transactionService;

        public GetTransactionsQueryHandler(ITransactionService transactionService)
        {
            _transactionService = transactionService;

        }
        public async Task<IQueryable<Transaction>> Handle(GetTransactionsQuery request, CancellationToken cancellationToken)
        {
            return await _transactionService.GetTransactions();     
        }
    }
}
