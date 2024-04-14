using Bank.Service.Interfaces.Services;
using Domain.Entities;
using MediatR;

namespace Mediator.Queries
{
    public record GetTransactionQuery(int Id) : IRequest<Transaction>;

    public class GetTransactionQueryHandler : IRequestHandler<GetTransactionQuery, Transaction>
    {
        private readonly ITransactionService _transactionService;

        public GetTransactionQueryHandler(ITransactionService transactionService)
        {
            _transactionService = transactionService;

        }
        public async Task<Transaction> Handle(GetTransactionQuery request, CancellationToken cancellationToken)
        {
            return await _transactionService.GetTransaction(request.Id);
        }
    }
}
