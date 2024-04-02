using Bank.Service.Interfaces.Services;
using Infrastructure.DTO;
using MediatR;

namespace Mediator.Commands
{
    public record CreateTransactionCommand(decimal Amount,  int FromAccountId, int ToAccountId) : IRequest<Transaction>;

    public class CreateTransactionCommandHandler : IRequestHandler<CreateTransactionCommand, Transaction>
    {
        private readonly ITransactionService _transactionService;

        public CreateTransactionCommandHandler(ITransactionService transactionService)
        {
            _transactionService = transactionService;
        }
        public async Task<Transaction> Handle(CreateTransactionCommand request, CancellationToken cancellationToken)
        {
            var transaction = new Transaction();
            transaction.Amount = request.Amount;
            transaction.FromAccount.Id = request.FromAccountId;
            transaction.ToAccount.Id = request.ToAccountId;
          
            _transactionService.CreateTransaction(transaction);
            return await _transactionService.GetTransaction(transaction.Id);
        }
    }
}
