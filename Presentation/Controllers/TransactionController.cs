using Mediator.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using TeraBank.API.Models;
using Mediator.Commands;

namespace Presentation.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TransactionController : ControllerBase
    {
        private readonly IMediator _mediator;
        public TransactionController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetTransaction(int id)
        {
            var transaction = await _mediator.Send(new GetTransactionQuery(id));
            return Ok(transaction);
        }

        [HttpGet]
        public async Task<IActionResult> GetTransactions()
        {
            var transactions = await _mediator.Send(new GetTransactionsQuery());
            return Ok(transactions);
        }

        [HttpPost]
        public async Task<IActionResult> CreateTransaction([FromBody] TransactionModel transactionModel)
        {          
            var transaction = await _mediator.Send(new CreateTransactionCommand(transactionModel.Amount, transactionModel.FromAccountId, transactionModel.ToAccountId));
            return Ok(transaction);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateTransaction([FromBody] TransactionModel transactionModel)
        {
            var transaction = await _mediator.Send(new UpdateTransactionCommand(transactionModel.Amount, transactionModel.FromAccountId, transactionModel.ToAccountId));
            return Ok(transaction);
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteTransaction(int id)
        {
            await _mediator.Send(new DeleteTransactionCommand(id));
            return Ok();
        }
    }
}
