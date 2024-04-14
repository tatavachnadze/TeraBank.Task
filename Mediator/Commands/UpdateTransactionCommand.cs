using Bank.Service.Interfaces.Services;
using Domain.Entities;
using MediatR;

namespace Mediator.Commands
{
    public record UpdateTransactionCommand(decimal Amount, int FromAccountId, int ToAccountId) : IRequest<Transaction>;

    public class UpdateTransactionCommandHandler : IRequestHandler<UpdateTransactionCommand, Transaction>
    {
        private readonly ITransactionService _transactionService;

        public UpdateTransactionCommandHandler(ITransactionService transactionService)
        {
            _transactionService = transactionService;
        }
        public async Task<Transaction> Handle(UpdateTransactionCommand request, CancellationToken cancellationToken)
        {
            var transaction = new Transaction();
            transaction.Amount = request.Amount;
            transaction.FromAccount.Id = request.FromAccountId;
            transaction.ToAccount.Id = request.ToAccountId;

            _transactionService.UpdateTransaction(transaction);
            return await _transactionService.GetTransaction(transaction.Id);
        }
    }
}
