using Bank.Service.Interfaces.Services;
using MediatR;

namespace Mediator.Commands
{
    public record DeleteTransactionCommand(int Id) : IRequest;

    public class DeleteTransactionCommandHandler : IRequestHandler<DeleteTransactionCommand>
    {
        private readonly ITransactionService _transactionService;
        public DeleteTransactionCommandHandler(ITransactionService transactionService)
        {
            _transactionService = transactionService;
        }
        public async Task Handle(DeleteTransactionCommand request, CancellationToken cancellationToken)
        {
            await Task.Run(() => { _transactionService.DeleteTransaction(request.Id); }, cancellationToken);                      
        }
    }
}
