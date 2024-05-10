using Bank.Service;
using Bank.Service.Interfaces.Services;
using Domain.Entities;
using MediatR;

namespace Mediator.Queries
{
    public record GetTransactionsQuery() : IRequest<IQueryable<Transaction>>;

    public class GetTransactionsQueryHandler : IRequestHandler<GetTransactionsQuery, IEnumerable<Transaction>>
    {
        private readonly ITransactionService _transactionService;

        public GetTransactionsQueryHandler(ITransactionService transactionService)
        {
            _transactionService = transactionService;

        }
        public async Task<IEnumerable<Transaction>> Handle(GetTransactionsQuery request, CancellationToken cancellationToken)
        {
            return await _transactionService.GetTransactions();     
        }
    }
}
