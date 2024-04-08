using Mediator.Commands;
using Mediator.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using TeraBank.API.Models;

namespace TeraBank.Task.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AccountController : ControllerBase
    {
        private readonly IMediator _mediator;

        public AccountController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetAccount(int id)
        {
            var account = await _mediator.Send(new GetAccountQuery(id));
            return Ok(account);
        }

        [HttpGet]
        public async Task<IActionResult> GetAccounts()
        {
            var accounts = await _mediator.Send(new GetAccountsQuery());
            return Ok(accounts);
        }

        [HttpPost]
        public async Task<IActionResult> CreateAccount([FromBody] AccountModel accountModel)
        {
            var account = await _mediator.Send(new CreateAccountCommand(accountModel.IBAN, accountModel.Balance, accountModel.customerId, accountModel.cardId));
            return Ok(account);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateAccount([FromBody] AccountModel accountModel)
        {
            var account = await _mediator.Send(new UpdateAccountCommand(accountModel.IBAN, accountModel.Balance, accountModel.customerId, accountModel.cardId));
            return Ok(account);
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> SuspendAccount(int id)
        {
            await _mediator.Send(new SuspendAccountCommand(id));
            return Ok();
        }

        [HttpPut("{id:int}/resume")]
        public async Task<IActionResult> ResumeAccount(int id)
        {
            await _mediator.Send(new ResumeAccountCommand(id));
            return Ok();
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteAccount(int id)
        {
            await _mediator.Send(new DeleteAccountCommand(id));
            return Ok();
        }
    }
}
