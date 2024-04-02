using Bank.Service.Interfaces.Services;
using Infrastructure.DTO;
using Mediator.Commands;
using Mediator.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using TeraBank.API.Models;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace TeraBank.Task.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AccountController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly ILogger<AccountController> _logger;

        public AccountController(IMediator mediator, ILogger<AccountController> logger)
        {
            _mediator = mediator;
            _logger = logger;
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
        public async Task<IActionResult> CreateAccount(AccountModel accountModel)
        {
            var account = await _mediator.Send(new CreateAccountCommand(accountModel.IBAN, accountModel.Balance, accountModel.customerId, accountModel.cardId));
            return Ok(account);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateAccount(AccountModel accountModel)
        {
            var account = await _mediator.Send(new UpdateAccountCommand(accountModel.IBAN, accountModel.Balance, accountModel.customerId, accountModel.cardId));
            return Ok(account);
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> SuspendAccount(int id)
        {
            var account = await _mediator.Send(new SuspendAccountCommand(id));
            return Ok(account);
        }

        [HttpPut("{id:int}")]
        public Task ResumeAccount(int id)
        {
            _accountService.ResumeAccount(id);
            return Task.CompletedTask;
        }

        [HttpDelete("{id:int}")]
        public Task DeleteAccount(int id)
        {
            _accountService.DeleteAccount(id);
            return Task.CompletedTask;
        }
    }
}
